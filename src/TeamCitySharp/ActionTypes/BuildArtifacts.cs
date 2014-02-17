using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

using TeamCitySharp.Connection;

namespace TeamCitySharp.ActionTypes
{
    internal class BuildArtifacts : IBuildArtifacts
    {
        private readonly ITeamCityCaller _caller;

        public BuildArtifacts(ITeamCityCaller caller)
        {
            _caller = caller;
        }

        public void DownloadArtifactsByBuildId(string buildId, Action<string> downloadHandler)
        {
            _caller.GetDownloadFormat(downloadHandler, "/downloadArtifacts.html?buildId={0}", buildId);
        }

        public ArtifactWrapper ByBuildConfigId(string buildConfigId)
        {
            return new ArtifactWrapper(_caller, buildConfigId);
        }
    }

    public class ArtifactWrapper
    {
        private readonly ITeamCityCaller _caller;
        private readonly string _buildConfigId;

        internal ArtifactWrapper(ITeamCityCaller caller, string buildConfigId)
        {
            _caller = caller;
            _buildConfigId = buildConfigId;
        }

        public ArtifactCollection LastFinished()
        {
            return Specification(".lastFinished");
        }

        public ArtifactCollection LastPinned()
        {
            return Specification(".lastPinned");
        }

        public ArtifactCollection LastSuccessful()
        {
            return Specification(".lastSuccessful");
        }

        public ArtifactCollection Tag(string tag)
        {
            return Specification(tag + ".tcbuildtag");
        }

        public ArtifactCollection Specification(string buildSpecification)
        {
            var xml = _caller.GetRaw(string.Format("/repository/download/{0}/{1}/teamcity-ivy.xml", _buildConfigId, buildSpecification));

            var document = new XmlDocument();
            document.LoadXml(xml);
            var artifactNodes = document.SelectNodes("//artifact");
            if (artifactNodes == null)
            {
                return null;
            }
            var list = new List<string>();
            foreach (XmlNode node in artifactNodes)
            {
                var nameNode = node.SelectSingleNode("@name");
                var extensionNode = node.SelectSingleNode("@ext");
                var artifact = string.Empty;
                if (nameNode != null)
                {
                    artifact = nameNode.Value;
                }
                if (extensionNode != null)
                {
                    artifact += "." + extensionNode.Value;
                }
                list.Add(string.Format("/repository/download/{0}/{1}/{2}", _buildConfigId, buildSpecification, artifact));
            }
            return new ArtifactCollection(_caller, list);
        }
    }

    public class ArtifactCollection
    {
        private readonly ITeamCityCaller _caller;
        private readonly List<string> _urls;

        internal ArtifactCollection(ITeamCityCaller caller, List<string> urls)
        {
            _caller = caller;
            _urls = urls;
        }

        /// <summary>
        /// Takes a list of artifact urls and downloads them, see ArtifactsBy* methods.
        /// </summary>
        /// <param name="directory">
        /// Destination directory for downloaded artifacts, default is current working directory.
        /// </param>
        /// <param name="flatten">
        /// If <see langword="true"/> all files will be downloaded to destination directory, no subfolders will be created.
        /// </param>
        /// <param name="overwrite">
        /// If <see langword="true"/> files that already exist where a downloaded file is to be placed will be deleted prior to download.
        /// </param>
        /// <returns>
        /// A list of full paths to all downloaded artifacts.
        /// </returns>
        public List<string> Download(string directory = null, bool flatten = false, bool overwrite = true)
        {
            if (directory == null)
            {
                directory = Directory.GetCurrentDirectory();
            }
            var downloaded = new List<string>();
            foreach (var url in _urls)
            {
                // user probably didnt use to artifact url generating functions
                Debug.Assert(url.StartsWith("/repository/download/"));

                // figure out local filename
                var parts = url.Split('/').Skip(5).ToArray();
                var destination = flatten
                    ? parts.Last()
                    : string.Join(Path.DirectorySeparatorChar.ToString(), parts);
                destination = Path.Combine(directory, destination);

                // create directories that doesnt exist
                var directoryName = Path.GetDirectoryName(destination);
                if (directoryName != null && !Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                // add artifact to list regardless if it was downloaded or skipped
                downloaded.Add(Path.GetFullPath(destination));

                // if the file already exists delete it or move to next artifact
                if (File.Exists(destination))
                {
                    if (overwrite) File.Delete(destination);
                    else continue;
                }
                _caller.GetDownloadFormat(tempfile => File.Move(tempfile, destination), url);
            }
            return downloaded;
        }

        /// <summary>
        /// Takes a list of artifact urls and downloads them, see ArtifactsBy* methods.
        /// </summary>
        /// <param name="directory">
        /// Destination directory for downloaded artifacts, default is current working directory.
        /// </param>
        /// <param name="flatten">
        /// If <see langword="true"/> all files will be downloaded to destination directory, no subfolders will be created.
        /// </param>
        /// <param name="overwrite">
        /// If <see langword="true"/> files that already exist where a downloaded file is to be placed will be deleted prior to download.
        /// </param>
        /// <param name="filteredFiles"></param>
        /// <returns>
        /// A list of full paths to all downloaded artifacts.
        /// </returns>
        public List<string> DownloadFiltered(string directory = null, List<string> filteredFiles = null, bool flatten = false, bool overwrite = true)
        {
          if (directory == null)
          {
            directory = Directory.GetCurrentDirectory();
          }
          var downloaded = new List<string>();
          foreach (var url in _urls)
          {
            if (filteredFiles != null)
              foreach (var filteredFile in filteredFiles)
              {
                var currentFilename = new Wildcard(GetFilename(filteredFile), RegexOptions.IgnoreCase);
                var currentExt = new Wildcard(GetExtension(filteredFile), RegexOptions.IgnoreCase);

                // user probably didnt use to artifact url generating functions
                Debug.Assert(url.StartsWith("/repository/download/"));

                // figure out local filename
                var parts = url.Split('/').Skip(5).ToArray();
                var destination = flatten
                    ? parts.Last()
                    : string.Join(Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture), parts);
                destination = Path.Combine(directory, destination);

               
                if (currentFilename.IsMatch(Path.GetFileNameWithoutExtension(destination)) &&
                    currentExt.IsMatch(Path.GetExtension(destination)))
                {
                  // create directories that doesnt exist
                  var directoryName = Path.GetDirectoryName(destination);
                  if (directoryName != null && !Directory.Exists(directoryName))
                  {
                    Directory.CreateDirectory(directoryName);
                  }

                  downloaded.Add(Path.GetFullPath(destination));

                  // if the file already exists delete it or move to next artifact
                  if (File.Exists(destination))
                  {
                    if (overwrite) File.Delete(destination);
                    else continue;
                  }
                  _caller.GetDownloadFormat(tempfile => File.Move(tempfile, destination), url);
                  break;
                }
              }
          }
          return downloaded;
        }
      private static string GetExtension(string path)
      {
        return path.Substring(path.LastIndexOf('.') );
      }
      private static string GetFilename(string path)
      {
        return path.Substring(0, path.LastIndexOf('.'));
      }
    }
    internal class Wildcard : Regex
    {
      /// <summary>
      /// Initializes a wildcard with the given search pattern.
      /// </summary>
      /// <param name="pattern">The wildcard pattern to match.</param>
      public Wildcard(string pattern)
        : base(WildcardToRegex(pattern))
      {
      }

      /// <summary>
      /// Initializes a wildcard with the given search pattern and options.
      /// </summary>
      /// <param name="pattern">The wildcard pattern to match.</param>
      /// <param name="options">A combination of one or more
      /// <see cref="RegexOptions"/>.</param>
      public Wildcard(string pattern, RegexOptions options)
        : base(WildcardToRegex(pattern), options)
      {
      }

      /// <summary>
      /// Converts a wildcard to a regex.
      /// </summary>
      /// <param name="pattern">The wildcard pattern to convert.</param>
      /// <returns>A regex equivalent of the given wildcard.</returns>
      public static string WildcardToRegex(string pattern)
      {
        return "^" + Regex.Escape(pattern).
                           Replace("\\*", ".*").
                           Replace("\\?", ".") + "$";
      }
    }
}
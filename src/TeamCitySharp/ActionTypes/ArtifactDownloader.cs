using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal sealed class ArtifactDownloader
    {
        private readonly ITeamCityCaller _caller;
        private readonly ISystemIOWrapper _systemIOWrapper;

        /// <summary>
        /// file extensions of supported archives as mentioned in TeamCity 8.x documentation: http://confluence.jetbrains.com/display/TCD8/Patterns+For+Accessing+Build+Artifacts
        /// </summary>
        private const string SupportedArchiveExtensions = ".zip;.jar;.war;.ear;.nupkg;.sit;.apk;.tar.gz;.tgz;.tar.gzip;.tar";

        private const string TeamCityRestUrlContentPart = "/content/";
        private const string TeamCityRestUrlMetadataPart = "/metadata/";
        private const string TeamCityRestUrlBegining = "/app/rest/builds/";
        private const char TeamCityArchiveIdentifier = '!';

        /// <summary>
        /// Constructor
        /// </summary>
        public ArtifactDownloader(ITeamCityCaller caller, ISystemIOWrapper systemIOWrapper)
        {
            _caller = caller;
            _systemIOWrapper = systemIOWrapper;
        }

        /// <summary>
        /// Downloads the specified list of artifacts using the provided configuration parameters
        /// </summary>
        /// <returns>
        /// The list of file paths to downloaded files.
        /// </returns>
        public List<string> Download(Artifacts artifacts, string artifactRelativeName, string directory, bool flatten, bool overwrite, bool extractArchives)
        {
            // validate that valid artifacts were provided
            if (artifacts == null)
            {
                throw new ArgumentException("Artifacts must be provided, please use one of the other methods of this class to retrieve them.");
            }

            // default the destination directory to the current directory if one was not provided.
            if (string.IsNullOrEmpty(directory))
            {
                directory = _systemIOWrapper.GetCurrentDirectory();
            }

            // build a list of urls to download.
            var urls = new List<string>();
            FillDownloadUrlList(artifacts, extractArchives, urls);

            var downloaded = new List<string>();
            foreach (var url in urls)
            {
                // user probably didnt use the artifact url retrieval functions
                if (!url.Contains(TeamCityRestUrlBegining) || !url.Contains(TeamCityRestUrlContentPart))
                {
                    throw new ArgumentException("Invalid artifact url provided! Please use one of the methods of the IBuildArtifacts interface to retrieve them.");
                }

                // figure out local filename
                var subStringToken = string.IsNullOrEmpty(artifactRelativeName) ? TeamCityRestUrlContentPart : artifactRelativeName;
                IEnumerable<string> parts = GetUrlParts(url, subStringToken);
                parts = parts.Select(part => part.TrimEnd(TeamCityArchiveIdentifier));
                var destination = flatten
                    ? parts.Last()
                    : string.Join(Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture), parts);
                destination = Path.Combine(directory, destination);

                // create directories that doesnt exist
                var directoryName = Path.GetDirectoryName(destination);
                if (directoryName != null && !_systemIOWrapper.DirectoryExists(directoryName))
                {
                    _systemIOWrapper.CreateDirectory(directoryName);
                }

                // add artifact to list regardless if it was downloaded or skipped
                downloaded.Add(Path.GetFullPath(destination));

                // if the file already exists delete it or move to next artifact
                if (_systemIOWrapper.FileExists(destination))
                {
                    if (overwrite) _systemIOWrapper.DeleteFile(destination);
                    else continue;
                }
                _caller.GetDownloadFormat(tempfile => _systemIOWrapper.MoveFile(tempfile, destination), url);
            }
            return downloaded;
        }

        private void FillDownloadUrlList(Artifacts artifacts, bool extractArchives, ICollection<string> urls)
        {
            foreach (var artifact in artifacts.Files)
            {
                if (extractArchives || !IsArtifactUnderArchive(artifact))
                {
                    if (IsFolder(artifact) || (extractArchives && IsArchive(artifact)))
                    {
                        // if this artifact is a folder or an archive that needs to be extracted, then recall
                        // this method recursively for the children of this artifact. 
                        if (artifact.Children != null)
                        {
                            var childArtifacts = _caller.Get<Artifacts>(artifact.Children.Href);
                            FillDownloadUrlList(childArtifacts, extractArchives, urls);
                        }
                    }
                    else
                    {
                        urls.Add(artifact.Content.Href);
                    }
                }
            }
        }

        private static IEnumerable<string> GetUrlParts(string url, string subStringToken)
        {
            var subStringIndex = url.IndexOf(subStringToken, StringComparison.InvariantCulture) + subStringToken.Length;

                      // remove the begining of the url that should not be returned as parts
            return url.Substring(subStringIndex)
                      // split the remaining url into parts based on the '/' split character, and removing empty entries.
                      .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                      // filter out any parts we don't want (e.g. parts that look like "!").
                      .Where(part => !part.Equals(TeamCityArchiveIdentifier.ToString(CultureInfo.InvariantCulture))).ToArray();
        }

        private static bool IsArtifactUnderArchive(Artifact artifact)
        {
            var parts = GetUrlParts(artifact.Href, TeamCityRestUrlMetadataPart);

            // if any part ends with '!' and is supported by TeamCity then return true, otherwise false.
            return parts.Any(part => part[part.Length - 1].Equals(TeamCityArchiveIdentifier) && IsArchiveSupported(part.TrimEnd(TeamCityArchiveIdentifier)));
        }

        /// <summary>
        /// Verifies the extension of the filename provided to see if it is an archive supported by TeamCity.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static bool IsArchiveSupported(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                var extension = Path.GetExtension(filename.ToLower());
                return !string.IsNullOrEmpty(extension) && SupportedArchiveExtensions.Contains(extension);
            }

            return false;
        }

        private static bool IsArchive(Artifact artifact)
        {
            // archives have a non-zero size, have a content href, and they must be supported by TeamCity.
            return (artifact.Size > 0) && (artifact.Content != null) && IsArchiveSupported(artifact.Name);
        }

        private static bool IsFolder(Artifact artifact)
        {
            // folders have no size and have no content
            return (artifact.Size == 0) && (artifact.Content == null);
        }
    }
}

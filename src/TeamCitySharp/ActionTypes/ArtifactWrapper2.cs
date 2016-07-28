using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    /// <remarks>
    /// This class is only supported by TeamCity 8.x and higher.
    /// </remarks>
    internal sealed class ArtifactWrapper2 : IArtifactWrapper2
    {
        private readonly ITeamCityCaller _caller;
        private readonly Artifacts _artifacts;
        private readonly string _artifactRelativeName;

        public ArtifactWrapper2(ITeamCityCaller caller, Artifacts artifacts, string artifactRelativeName)
        {
            _caller = caller;
            _artifacts = artifacts;
            _artifactRelativeName = artifactRelativeName;
        }

        /// <summary>
        /// The published artifacts
        /// </summary>
        public List<Artifact> Artifacts { get { return _artifacts.Files; } }

        /// <summary>
        /// Downloads the associated artifacts.
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
        /// <param name="extractArchives">
        /// If <see langword="true"/> files contained within archives will be downloaded individually under a directory with the archive's name.
        /// </param>
        /// <remarks>
        /// This method is only supported by TeamCity 8.x and higher.
        /// </remarks>
        public List<string> Download(string directory = null, bool flatten = false, bool overwrite = true, bool extractArchives = false)
        {
            var downloader = new ArtifactDownloader(_caller, new SystemIOWrapper());
            return downloader.Download(_artifacts, _artifactRelativeName, directory, flatten, overwrite, extractArchives);
        }
    }
}

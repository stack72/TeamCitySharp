using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    /// <remarks>
    /// This class is only supported by TeamCity 8.x and higher.
    /// </remarks>
    public interface IArtifactWrapper2
    {
        /// <summary>
        /// The published artifacts
        /// </summary>
        List<Artifact> Artifacts { get; }

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
        List<string> Download(string directory = null, bool flatten = false, bool overwrite = true, bool extractArchives = false);
    }
}
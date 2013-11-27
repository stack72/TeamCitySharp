using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IBuildArtifacts
    {
        void DownloadArtifactsByBuildId(string buildId, Action<string> downloadHandler);

        ArtifactWrapper ByBuildConfigId(string buildConfigId);

        /// <summary>
        /// Retrieves the artifacts associated to the specified <see cref="Build"/>.
        /// </summary>
        /// <param name="build">
        /// The TeamCity <see cref="Build"/> of the desired artifacts.
        /// </param>
        /// <param name="artifactRelativeName">
        /// the relative path and filename of a specific artifact. Supports referencing files under archives using the  &quot;!&quot; delimiter after the archive name.
        /// </param>
        /// <remarks>
        /// This method is only supported by TeamCity 8.x and higher.
        /// </remarks>
        IArtifactWrapper2 ByBuild(Build build, string artifactRelativeName = "");
    }
}
using System;

namespace TeamCitySharp.ActionTypes
{
  public interface IBuildArtifacts
  {
    void DownloadArtifactsByBuildId(string buildId, Action<string> downloadHandler);

    ArtifactWrapper ByBuildConfigId(string buildConfigId);
  }
}
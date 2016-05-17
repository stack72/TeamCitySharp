using System;
using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public class Builds : IBuilds
  {
    private readonly ITeamCityCaller _caller;
    private string _fields;

    internal Builds(ITeamCityCaller caller)
    {
      _caller = caller;
    }

    public Builds GetFields(string fields)
    {
      var newInstance = (Builds) MemberwiseClone();
      newInstance._fields = fields;
      return newInstance;
    }

    public List<Build> ByBuildLocator(BuildLocator locator)
    {
      var buildWrapper =
        _caller.GetFormat<BuildWrapper>(ActionHelper.CreateFieldUrl("/app/rest/builds?locator={0}", _fields), locator);
      return int.Parse(buildWrapper.Count) > 0 ? buildWrapper.Build : new List<Build>();
    }

    public List<Build> ByBuildLocator(BuildLocator locator, List<String> param)
    {
      var strParam = "";
      foreach (var tmpParam in param)
      {
        strParam += ",";
        strParam += tmpParam;
      }

      var buildWrapper =
        _caller.Get<BuildWrapper>(
          ActionHelper.CreateFieldUrl(string.Format("/app/rest/builds?locator={0}{1}", locator, strParam), _fields));

      return int.Parse(buildWrapper.Count) > 0 ? buildWrapper.Build : new List<Build>();
    }

    public Build LastBuildByAgent(string agentName)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(agentName: agentName, maxResults: 1)).SingleOrDefault();
    }

    public void Add2QueueBuildByBuildConfigId(string buildConfigId)
    {
      _caller.GetFormat("/action.html?add2Queue={0}", buildConfigId);
    }

    public List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                        status: BuildStatus.SUCCESS
                              ));
    }

    public List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId, List<String> param)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                        status: BuildStatus.SUCCESS
                              ), param);
    }


    public Build LastSuccessfulBuildByBuildConfigId(string buildConfigId)
    {
      var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                              status: BuildStatus.SUCCESS,
                                                              maxResults: 1
                                    ));
      return builds != null ? builds.FirstOrDefault() : new Build();
    }

    public List<Build> FailedBuildsByBuildConfigId(string buildConfigId)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                        status: BuildStatus.FAILURE
                              ));
    }

    public Build LastFailedBuildByBuildConfigId(string buildConfigId)
    {
      var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                              status: BuildStatus.FAILURE,
                                                              maxResults: 1
                                    ));
      return builds != null ? builds.FirstOrDefault() : new Build();
    }

    public Build LastBuildByBuildConfigId(string buildConfigId)
    {
      var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                              maxResults: 1
                                    ));
      return builds != null ? builds.FirstOrDefault() : new Build();
    }

    public List<Build> ErrorBuildsByBuildConfigId(string buildConfigId)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                        status: BuildStatus.ERROR
                              ));
    }

    public Build LastErrorBuildByBuildConfigId(string buildConfigId)
    {
      var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                              status: BuildStatus.ERROR,
                                                              maxResults: 1
                                    ));
      return builds != null ? builds.FirstOrDefault() : new Build();
    }

    public List<Build> ByBuildConfigId(string buildConfigId, List<String> param)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId)), param);
    }

    public Build ById(string id)
    {
      var build = _caller.GetFormat<Build>(ActionHelper.CreateFieldUrl("/app/rest/builds/id:{0}", _fields), id);

      return build ?? new Build();
    }

    public List<Build> ByBuildConfigId(string buildConfigId)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId)
                              ));
    }

    public List<Build> RunningByBuildConfigId(string buildConfigId)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId)),
                            new List<string> {"running:true"});
    }

    public List<Build> ByConfigIdAndTag(string buildConfigId, string tag)
    {
      return ByConfigIdAndTag(buildConfigId, new[] {tag});
    }

    public List<Build> ByConfigIdAndTag(string buildConfigId, string[] tags)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                        tags: tags
                              ));
    }

    public List<Build> ByUserName(string userName)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(
        user: UserLocator.WithUserName(userName)
                              ));
    }

    public List<Build> AllSinceDate(DateTime date)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(sinceDate: date));
    }

    public List<Build> AllRunningBuild()
    {
      var buildWrapper =
        _caller.GetFormat<BuildWrapper>(ActionHelper.CreateFieldUrl("/app/rest/builds?locator=running:true", _fields));
      return int.Parse(buildWrapper.Count) > 0 ? buildWrapper.Build : new List<Build>();
    }

    public List<Build> ByBranch(string branchName)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(branch: branchName));
    }

    public List<Build> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus)
    {
      return ByBuildLocator(BuildLocator.WithDimensions(sinceDate: date, status: buildStatus));
    }

    public List<Build> NonSuccessfulBuildsForUser(string userName)
    {
      var builds = ByUserName(userName);
      if (builds == null)
        return null;

      return builds.Where(b => b.Status != "SUCCESS").ToList();
    }

    public List<Build> RetrieveEntireBuildChainFrom(string buildConfigId)
    {
      var buildWrapper =
        _caller.GetFormat<BuildWrapper>(
          ActionHelper.CreateFieldUrl(
            "/app/rest/builds?locator=snapshotDependency:(from:(id:{0}),includeInitial:true),defaultFilter:false",
            _fields), buildConfigId);
      return int.Parse(buildWrapper.Count) > 0 ? buildWrapper.Build : new List<Build>();
    }

    public List<Build> RetrieveEntireBuildChainTo(string buildConfigId)
    {
      var buildWrapper =
        _caller.GetFormat<BuildWrapper>(
          ActionHelper.CreateFieldUrl(
            "/app/rest/builds?locator=snapshotDependency:(to:(id:{0}),includeInitial:true),defaultFilter:false", _fields),
          buildConfigId);
      return int.Parse(buildWrapper.Count) > 0 ? buildWrapper.Build : new List<Build>();
    }

    /// <summary>
    /// Retrieves the list of build after a build id. 
    /// 
    /// IMPORTANT NOTE: The list starts from the latest build to oldest  (Descending)
    /// </summary>
    /// <param name="buildid"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<Build> NextBuilds(string buildid, int count = 100)
    {
      var buildWrapper =
        _caller.GetFormat<BuildWrapper>(
          ActionHelper.CreateFieldUrl("/app/rest/builds?locator=sinceBuild:(id:{0}),count({1})", _fields),buildid,count);
      return int.Parse(buildWrapper.Count) > 0 ? buildWrapper.Build : new List<Build>();
    }
  }
}

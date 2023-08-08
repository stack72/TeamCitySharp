using System;
using System.Collections.Generic;

namespace TeamCitySharp.Locators
{
  public enum BuildStatus
  {
    SUCCESS,
    FAILURE,
    ERROR
  }

  public class BuildLocator
  {
    public static BuildLocator WithId(long id)
    {
      return new BuildLocator {Id = id};
    }

    public static BuildLocator WithNumber(string number)
    {
      return new BuildLocator {Number = number};
    }

    public static BuildLocator RunningBuilds()
    {
      return new BuildLocator {Running = true};
    }

    public static BuildLocator WithDimensions(BuildTypeLocator buildType = null,
                                              UserLocator user = null,
                                              string agentName = null,
                                              BuildStatus? status = null,
                                              bool? personal = null,
                                              bool? canceled = null,
                                              bool? running = null,
                                              bool? pinned = null,
                                              int? maxResults = null,
                                              int? startIndex = null,
                                              BuildLocator sinceBuild = null,
                                              DateTime? sinceDate = null,
                                              string[] tags = null,
                                              string branch = null,
                                              bool? defaultFilter = null,
                                              bool? failedToStart = null,
                                              bool? queued = null,
                                              bool? hanging = null,
                                              bool? finished = null

      )
    {
      return new BuildLocator
        {
          BuildType = buildType,
          User = user,
          AgentName = agentName,
          Status = status,
          Personal = personal,
          Canceled = canceled,
          Running = running,
          Pinned = pinned,
          MaxResults = maxResults,
          StartIndex = startIndex,
          SinceBuild = sinceBuild,
          SinceDate = sinceDate,
          Tags = tags,
          Branch = branch,
          DefaultFilter = defaultFilter,
          FailedToStart = failedToStart,
          Queued = queued,
          Hanging = hanging,
          Finished = finished
        };
    }

    public long? Id { get; private set; }
    public string Number { get; private set; }
    public string[] Tags { get; private set; }
    public BuildTypeLocator BuildType { get; private set; }
    public UserLocator User { get; private set; }
    public string AgentName { get; private set; }
    public BuildStatus? Status { get; private set; }
    public BuildLocator SinceBuild { get; private set; }
    public bool? Personal { get; private set; }
    public bool? Canceled { get; private set; }
    public bool? Running { get; private set; }
    public bool? Pinned { get; private set; }
    public int? MaxResults { get; private set; }
    public int? StartIndex { get; private set; }
    public DateTime? SinceDate { get; private set; }
    public string Branch { get; private set; }
    public bool? DefaultFilter { get; private set; }
    public bool? FailedToStart { get; private set; }
    public bool? Queued { get; private set; }
    public bool? Hanging { get; private set; }
    public bool? Finished { get; private set; }

    public override string ToString()
    {
      if (Id != null)
        return "id:" + Id;

      if (Number != null)
        return "number:" + Number;

      var locatorFields = new List<string>();

      if(DefaultFilter != null)
        locatorFields.Add("defaultFilter:" + DefaultFilter.Value.ToString());

      if (BuildType != null)
        locatorFields.Add("buildType:(" + BuildType + ")");

      if (User != null)
        locatorFields.Add("user:(" + User + ")");

      if (Tags != null)
        locatorFields.Add("tags:(" + string.Join(",", Tags) + ")");

      if (SinceBuild != null)
        locatorFields.Add("sinceBuild:(" + SinceBuild + ")");

      if (!string.IsNullOrEmpty(AgentName))
        locatorFields.Add("agentName:" + AgentName);

      if (Status.HasValue)
        locatorFields.Add("status:" + Status.Value.ToString());

      if (Personal.HasValue)
        locatorFields.Add("personal:" + Personal.Value.ToString());

      if (Canceled.HasValue)
        locatorFields.Add("canceled:" + Canceled.Value.ToString());

      if (Running.HasValue)
        locatorFields.Add("running:" + Running.Value.ToString());

      if (Pinned.HasValue)
        locatorFields.Add("pinned:" + Pinned.Value.ToString());

      if(FailedToStart != null)
        locatorFields.Add("failedToStart:" + FailedToStart.Value.ToString());

      if(Queued != null)
        locatorFields.Add("queued:" + Queued.Value.ToString());

      if(Hanging != null)
        locatorFields.Add("hanging:" + Hanging.Value.ToString());

      if(Finished != null)
        locatorFields.Add("finished:" + Finished.Value.ToString());

      if (MaxResults.HasValue)
        locatorFields.Add("count:" + MaxResults.Value.ToString());

      if (StartIndex.HasValue)
        locatorFields.Add("start:" + StartIndex.Value.ToString());

      if (SinceDate.HasValue)
      {
        locatorFields.Add("sinceDate:" +
                          SinceDate.Value.ToString("yyyyMMdd'T'HHmmsszzzz").Replace(":", "").Replace("+", "-"));
      }

      if (Branch != null)
        locatorFields.Add("branch:(" + Branch + ")");

      return string.Join(",", locatorFields.ToArray());
    }
  }
}
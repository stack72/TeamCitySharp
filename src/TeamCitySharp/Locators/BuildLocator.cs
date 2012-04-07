using System;
using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.Locators
{
    public enum BuildStatus
    {
        SUCCESS,
        FAILURE,
        ERROR
    }
	
	public class BuildQuery
	{
        private readonly TeamCityCaller _caller;
		
		internal BuildQuery(TeamCityCaller caller)
		{
			_caller = caller;
		}
		
		public BuildLocator Locator { get; set; }
		
		public Build Latest()
		{
            return _caller.GetFormat<Build>("/app/rest/builds/{0}", Locator.ToString());
		}
		
		public List<BuildRef> List(long? skip = null, long? take = null)
		{
			var query = Locator.ToString();
			
			if (skip.HasValue)
			{
				query += ",start:" + skip.Value;
			}
			if (take.HasValue)
			{
				query += ",count:" + take.Value;
			}
			
            return _caller.GetFormat<BuildWrapper>("/app/rest/builds?locator={0}", query).Build ?? new List<BuildRef>();
		}
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

        public static BuildLocator WithDimensions(BuildTypeLocator buildType = null,
                                                    UserLocator user = null,
                                                    string agentName = null,
                                                    BuildStatus? status = null,
                                                    bool? personal = null,
                                                    bool? canceled = null,
                                                    bool? running = null,
                                                    bool? pinned = null,
                                                    BuildLocator sinceBuild = null,
                                                    DateTime? sinceDate = null,
                                                    string[] tags = null
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
                           SinceBuild = sinceBuild,
                           SinceDate = sinceDate,
                           Tags = tags
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
        public DateTime? SinceDate { get; private set; }

        public override string  ToString()
        {
            if (Id != null)
            {
                return "id:" + Id;
            }

            if (Number != null)
            {
                return "number:" + Number;
            }

            var locatorFields = new List<string>();

            if (BuildType != null)
            {
                locatorFields.Add("buildType:(" + BuildType + ")");
            }

            if (User != null)
            {
                locatorFields.Add("user:(" + User + ")");
            }

            if (Tags != null)
            {
                locatorFields.Add("tags:(" + string.Join(",", Tags) + ")");
            }

            if (SinceBuild != null)
            {
                locatorFields.Add("sinceBuild:(" + SinceBuild + ")");
            }

            if(!string.IsNullOrEmpty(AgentName))
            {
                locatorFields.Add("agentName:" + AgentName);
            }

            if(Status.HasValue)
            {
                locatorFields.Add("status:" + Status.Value.ToString());
            }

            if(Personal.HasValue)
            {
                locatorFields.Add("personal:" + Personal.Value.ToString());
            }

            if(Canceled.HasValue)
            {
                locatorFields.Add("canceled:" + Canceled.Value.ToString());
            }

            if(Running.HasValue)
            {
                locatorFields.Add("running:" + Running.Value.ToString());
            }

            if(Pinned.HasValue)
            {
                locatorFields.Add("pinned:" + Pinned.Value.ToString());
            }

            if (SinceDate.HasValue)
            {
                locatorFields.Add("sinceDate:" +
                                  SinceDate.Value.ToString("yyyyMMdd'T'HHmmsszzzz").Replace(":", "").Replace("+", "-"));
            }

            return string.Join(",", locatorFields.ToArray());
        }
    }
}
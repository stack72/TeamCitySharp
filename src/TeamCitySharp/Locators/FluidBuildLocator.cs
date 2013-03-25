using System;
using System.Collections.Generic;
using TeamCitySharp.Locators;

namespace TeamCitySharp.Locators
{

    public class FluidBuildLocator : IBuildLocator
    {

        #region Constructors

        public FluidBuildLocator()
            : base()
        {
        }

        #endregion

        #region Properties

        public long? Id
        {
            get;
            private set;
        }

        public string Number
        {
            get;
            private set;
        }

        public string[] Tags
        {
            get;
            private set;
        }

        public IBuildTypeLocator BuildType
        {
            get;
            private set;
        }

        public IUserLocator User
        {
            get;
            private set;
        }

        public string AgentName
        {
            get;
            private set;
        }

        public BuildStatus? Status
        {
            get;
            private set;
        }

        public IBuildLocator SinceBuild
        {
            get;
            private set;
        }

        public bool? Personal
        {
            get;
            private set;
        }

        public bool? Cancelled
        {
            get;
            private set;
        }

        public bool? Running
        {
            get;
            private set;
        }

        public bool? Pinned
        {
            get;
            private set;
        }

        public int? MaxResults
        {
            get;
            private set;
        }

        public int? StartIndex
        {
            get;
            private set;
        }

        public DateTime? SinceDate
        {
            get;
            private set;
        }

        public IBranchLocator Branch
        {
            get;
            private set;
        }

        #endregion

        #region Fluid Methods

        public static FluidBuildLocator WithId(long id)
        {
            return new FluidBuildLocator { Id = id };
        }

        public static FluidBuildLocator WithNumber(string number)
        {
            return new FluidBuildLocator { Number = number };
        }

        public FluidBuildLocator WithTags(string[] tags)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.Tags = tags;
            return clone;
        }

        public FluidBuildLocator WithBuildType(FluidBuildTypeLocator buildType)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.BuildType = buildType;
            return clone;
        }

        public FluidBuildLocator WithUser(IUserLocator user)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.User = user;
            return clone;
        }

        public FluidBuildLocator WithAgentName(string agentName)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.AgentName = agentName;
            return clone;
        }

        public FluidBuildLocator WithStatus(BuildStatus? status)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.Status = status;
            return clone;
        }

        public FluidBuildLocator WithSinceBuild(IBuildLocator sinceBuild)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.SinceBuild = sinceBuild;
            return clone;
        }

        public FluidBuildLocator WithPersonal(bool? personal)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.Personal = personal;
            return clone;
        }

        public FluidBuildLocator WithCancelled(bool? cancelled)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.Cancelled = cancelled;
            return clone;
        }

        public FluidBuildLocator WithRunning(bool? running)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.Running = running;
            return clone;
        }

        public FluidBuildLocator WithPinned(bool? pinned)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.Pinned = pinned;
            return clone;
        }

        public FluidBuildLocator WithMaxResults(int? maxResults)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.MaxResults = maxResults;
            return clone;
        }

        public FluidBuildLocator WithStartIndex(int? startIndex)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.StartIndex = startIndex;
            return clone;
        }

        public FluidBuildLocator WithSinceDate(DateTime? sinceDate)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.SinceDate = sinceDate;
            return clone;
        }

        public FluidBuildLocator WithBranch(IBranchLocator branch)
        {
            var clone = (FluidBuildLocator)this.MemberwiseClone();
            clone.Branch = branch;
            return clone;
        }

        public FluidBuildLocator WithDimensions(IBuildTypeLocator buildType = null,
                                    IUserLocator user = null,
                                    string agentName = null,
                                    BuildStatus? status = null,
                                    bool? personal = null,
                                    bool? cancelled = null,
                                    bool? running = null,
                                    bool? pinned = null,
                                    int? maxResults = null,
                                    int? startIndex = null,
                                    IBuildLocator sinceBuild = null,
                                    DateTime? sinceDate = null,
                                    string[] tags = null,
                                    IBranchLocator branch = null
                                )
        {
            return new FluidBuildLocator
            {
                BuildType = buildType,
                User = user,
                AgentName = agentName,
                Status = status,
                Personal = personal,
                Cancelled = cancelled,
                Running = running,
                Pinned = pinned,
                MaxResults = maxResults,
                StartIndex = startIndex,
                SinceBuild = sinceBuild,
                SinceDate = sinceDate,
                Tags = tags,
                Branch = branch
            };
        }

        public static FluidBuildLocator RunningBuilds()
        {
            return new FluidBuildLocator { Running = true };
        }

        #endregion

        #region Object Interface

        public override string ToString()
        {

            var dimensions = new List<string>();

            // the "id" and "number" dimensions aren't technically mutually exclusive,
            // but it doesn't make sense to use both together, and "id" is more
            // specific than "number" so we'll use that if it's given.
            if (Id != null)
            {
                dimensions.Add("id:" + Id + "");
            }
            else if (Number != null)
            {
                dimensions.Add("number:" + Number + "");
            }

            // add remaining dimensions. these can be used in conjunction with id and number.
            if (BuildType != null)
            {
                dimensions.Add("buildType:(" + BuildType + ")");
            }
            if (User != null)
            {
                dimensions.Add("user:(" + User + ")");
            }
            if (Tags != null)
            {
                dimensions.Add("tags:(" + string.Join(",", Tags) + ")");
            }
            if (SinceBuild != null)
            {
                dimensions.Add("sinceBuild:(" + SinceBuild + ")");
            }
            if (!string.IsNullOrEmpty(AgentName))
            {
                dimensions.Add("agentName:" + AgentName);
            }
            if (Status.HasValue)
            {
                dimensions.Add("status:" + Status.Value.ToString());
            }
            if (Personal.HasValue)
            {
                dimensions.Add("personal:" + Personal.Value.ToString());
            }
            if (Cancelled.HasValue)
            {
                dimensions.Add("canceled:" + Cancelled.Value.ToString());
            }
            if (Running.HasValue)
            {
                dimensions.Add("running:" + Running.Value.ToString());
            }
            if (Pinned.HasValue)
            {
                dimensions.Add("pinned:" + Pinned.Value.ToString());
            }
            if (MaxResults.HasValue)
            {
                dimensions.Add("count:" + MaxResults.Value.ToString());
            }
            if (StartIndex.HasValue)
            {
                dimensions.Add("start:" + StartIndex.Value.ToString());
            }
            if (SinceDate.HasValue)
            {
                dimensions.Add("sinceDate:" +
                               SinceDate.Value.ToString("yyyyMMdd'T'HHmmsszzzz").Replace(":", "").Replace("+", "-"));
            }
            if (Branch != null)
            {
                dimensions.Add("branch:(" + Branch.ToString() + ")");
            }

            return string.Join(",", dimensions.ToArray());
        }

        #endregion

    }

}
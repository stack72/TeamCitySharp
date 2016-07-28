using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.Locators
{
    public class ChangeLocator
    {
        public static ChangeLocator WithId(string id)
        {
            return new ChangeLocator() {Id = id};
        }

        public static ChangeLocator WithBuildId(long id)
        {
            return new ChangeLocator {Build = BuildLocator.WithId(id)};
        }

        public static ChangeLocator WithDimensions(string id,
            string project = null,
            BuildTypeLocator buildType = null,
            BuildLocator build = null,
            string vcsRoot = null,
            string vcsRootInstance = null,
            string userName = null,
            UserLocator user = null,
            string version = null,
            string internalVersion = null,
            string comment = null,
            string file = null,
            ChangeLocator sinceChange = null,
            int? maxResults = null,
            int? startIndex = null
            )
        {
            return new ChangeLocator
            {
                Build = build,
                BuildType = buildType,
                Comment = comment,
                File = file,
                Id = id,
                InternalVersion = internalVersion,
                MaxResults = maxResults,
                Project = project,
                SinceChange = sinceChange,
                StartIndex = startIndex,
                Version = version,
                VcsRoot = vcsRoot,
                VcsRootInstance = vcsRootInstance,
                User = user,
                UserName = userName
            };
        }

        public string Id { get; private set; }
        public string Project { get; private set; }
        public BuildTypeLocator BuildType { get; private set; }
        public BuildLocator Build { get; private set; }
        public string VcsRoot { get; private set; }
        public string VcsRootInstance { get; private set; }
        public string UserName { get; private set; }
        public UserLocator User { get; private set; }
        public string Version { get; private set; }
        public string InternalVersion { get; private set; }
        public string Comment { get; private set; }
        public string File { get; private set; }
        public ChangeLocator SinceChange { get; private set; }
        public int? MaxResults { get; private set; }
        public int? StartIndex { get; private set; }

        public override string ToString()
        {
            if (Id != null)
            {
                return "id:" + Id;
            }

            var locatorFields = new List<string>();

            if (BuildType != null)
            {
                locatorFields.Add("buildType:(" + BuildType + ")");
            }

            if (Build != null)
            {
                locatorFields.Add("build:(" + Build + ")");
            }

            if (User != null)
            {
                locatorFields.Add("user:(" + User + ")");
            }

            if (SinceChange != null)
            {
                locatorFields.Add("sinceChange:(" + SinceChange + ")");
            }

            if (!String.IsNullOrEmpty(Project))
            {
                locatorFields.Add("project:" + Project);
            }

            if (!String.IsNullOrEmpty(VcsRoot))
            {
                locatorFields.Add("vcsRoot:" + VcsRoot);
            }

            if (!String.IsNullOrEmpty(VcsRootInstance))
            {
                locatorFields.Add("vcsRootInstance:" + VcsRootInstance);
            }

            if (!String.IsNullOrEmpty(UserName))
            {
                locatorFields.Add("userName:" + UserName);
            }

            if (!String.IsNullOrEmpty(Version))
            {
                locatorFields.Add("version:" + Version);
            }

            if (!String.IsNullOrEmpty(InternalVersion))
            {
                locatorFields.Add("internalVersion:" + InternalVersion);
            }

            if (!String.IsNullOrEmpty(Comment))
            {
                locatorFields.Add("comment:" + Comment);
            }

            if (!String.IsNullOrEmpty(File))
            {
                locatorFields.Add("file:" + File);
            }

            if (MaxResults.HasValue)
            {
                locatorFields.Add("count:" + MaxResults.Value.ToString());
            }

            if (StartIndex.HasValue)
            {
                locatorFields.Add("start:" + StartIndex.Value.ToString());
            }

            return string.Join(",", locatorFields.ToArray());
        }
    }
}

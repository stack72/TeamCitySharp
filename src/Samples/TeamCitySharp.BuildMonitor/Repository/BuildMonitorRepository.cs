using System;
using System.Linq;
using BuildMonitor.Models;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace BuildMonitor.Repository
{
    public class BuildMonitorRepository : IDisposable
    {
        private TeamCitySharp.TeamCityClient client;
        private List<ProjectModel> projectList;
        private List<Project> projects;
        private List<BuildConfig> buildConfigs;
        private List<BuildConfig> currentProjectConfigs;

        public BuildMonitorRepository(string hostName)
        {
            client = new TeamCitySharp.TeamCityClient(hostName, false);

            projectList = new List<ProjectModel>();
            projects = GetAllProjects();
            buildConfigs = GetAllBuildConfigs();

        }

        public List<ProjectModel> GetAllProjectSummary()
        {
            try
            {
                foreach (Project proj in projects)
                {
                    try
                    {
                        currentProjectConfigs = (from configs in buildConfigs
                                                 where configs.ProjectId == proj.Id
                                                 select configs).ToList<BuildConfig>();


                        foreach (BuildConfig currentConfig in currentProjectConfigs)
                        {
                            var build = GetLatestBuildForConfig(currentConfig.Id);

                            ProjectModel project = new ProjectModel()
                            {
                                ProjectName = proj.Name,
                                ProjectId = proj.Id,
                                BuildConfigName = currentConfig.Name,
                                LastBuildTime = build.StartDate.ToString("dd/MM/yyyy HH:mm:ss"),
                                LastBuildStatus = build.Status,
                                LastBuildStatusText = build.StatusText
                            };
                            if (Properties.Settings.Default.ShowFailedBuildsOnly)
                            {
                                if (build.Status != "SUCCESS")
                                    projectList.Add(project);
                            }
                            else
                            {
                                projectList.Add(project);
                            }

                        }

                    }
                    catch (ArgumentNullException)
                    {
                        ProjectModel project = new ProjectModel()
                        {
                            ProjectName = proj.Name,
                            ProjectId = proj.Id,
                            BuildConfigName = "** No Builds available **",
                            LastBuildTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                            LastBuildStatus = "undefined",
                            LastBuildStatusText = String.Empty
                        };
                        projectList.Add(project);
                    }
                    catch (NullReferenceException)
                    {
                        ProjectModel project = new ProjectModel()
                        {
                            ProjectName = proj.Name,
                            ProjectId = proj.Id,
                            BuildConfigName = String.Empty,
                            LastBuildTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                            LastBuildStatus = "undefined",
                            LastBuildStatusText = String.Empty
                        };
                        projectList.Add(project);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

                return projectList
                    .OrderBy(x => x.LastBuildStatus.ToLower().Contains("success") ? 3 : 0)
                    .ThenBy(x => x.LastBuildStatus.ToLower().Contains("undefined") ? 2 : 0)
                    .ThenBy(x => x.LastBuildStatus.ToLower().Contains("unknown") ? 2 : 0)
                    .ThenBy(x => x.LastBuildStatus.ToLower().Contains("failure") ? 1 : 0)
                    .ToList<ProjectModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private List<Project> GetAllProjects()
        {
            client.Connect(
                          Properties.Settings.Default.TeamCityUser,
                          Properties.Settings.Default.TeamCityPwd,
                          Properties.Settings.Default.TeamCityIsGuest
                          );


            return client.AllProjects();
        }

        private List<BuildConfig> GetAllBuildConfigs()
        {
            client.Connect(
                            Properties.Settings.Default.TeamCityUser,
                            Properties.Settings.Default.TeamCityPwd,
                            Properties.Settings.Default.TeamCityIsGuest
                          );
            return client.AllBuildConfigs();
        }

        private Build GetLatestBuildForConfig(string configId)
        {
            client.Connect(
                            Properties.Settings.Default.TeamCityUser,
                            Properties.Settings.Default.TeamCityPwd,
                            Properties.Settings.Default.TeamCityIsGuest
                          );
            return client.LastBuildByBuildConfigId(configId);
        }

        public void Dispose()
        {
            client = null;
            projectList = null;
            projects = null;
            buildConfigs = null;
        }
    }
}
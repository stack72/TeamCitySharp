using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildMonitor.Models;
using TeamCitySharp.DomainEntities;

namespace BuildMonitor.Repository
{
    public class BuildMonitorRepository
    {
        private TeamCitySharp.TeamCityClient client;

        public BuildMonitorRepository(string hostName)
        {
            client = new TeamCitySharp.TeamCityClient(hostName, false);           
        }
        public List<ProjectModel> GetAllProjectSummary()
        {
            try
            {

                List<ProjectModel> projectList = new List<ProjectModel>();
         
                foreach (Project proj in GetAllProjects())
                {
                    try
                    {
                        foreach (BuildConfig config in GetBuildConfigsByProject(proj.Id))
                        {


                            var build = GetLatestBuildForConfig(config.Id);

                            ProjectModel project = new ProjectModel()
                            {
                                ProjectName = proj.Name,
                                ProjectId = proj.Id,
                                BuildConfigName = config.Name,
                                LastBuildTime = DateTime.ParseExact(build.StartDate, "yyyyMMddTHHmmsszzzzz", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy HH:mm:ss"),
                                LastBuildStatus = build.Status,
                                LastBuildStatusText = build.StatusText
                            };
                            projectList.Add(project);

                        }

                    }
                    catch (NullReferenceException)
                    {
                        ProjectModel project = new ProjectModel()
                        {
                            ProjectName = proj.Name,
                            ProjectId = proj.Id,
                            BuildConfigName = String.Empty,
                            LastBuildTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                            LastBuildStatus = null,
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

        private List<BuildConfig> GetBuildConfigsByProject(string projectId)
        {
            client.Connect(Properties.Settings.Default.TeamCityUser,
                           Properties.Settings.Default.TeamCityPwd,
                           Properties.Settings.Default.TeamCityIsGuest
                          );

            return client.BuildConfigsByProjectId(projectId);
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

    }
}
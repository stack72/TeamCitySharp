using System.Collections.Generic;

using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IBuildSteps
    {
        IList<BuildStep> ByConfigurationId(string buildConfigId);
        void Create(string buildConfigId, BuildStep buildStep);
    }
}
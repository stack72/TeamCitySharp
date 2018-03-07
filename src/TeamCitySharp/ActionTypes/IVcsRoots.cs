using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public interface IVcsRoots
  {
    VcsRoots GetFields(string fields);
    List<VcsRoot> All();
    VcsRoot ById(string vcsRootId);
    VcsRoot AttachVcsRoot(BuildTypeLocator locator, VcsRoot vcsRoot);
    void DetachVcsRoot(BuildTypeLocator locator, string vcsRootId);
    void SetVcsRootValue(VcsRoot vcsRoot, VcsRootValue field, object value);
  }
}
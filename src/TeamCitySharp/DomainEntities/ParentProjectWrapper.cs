using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamCitySharp.Locators;

namespace TeamCitySharp.DomainEntities
{
  public class ParentProjectWrapper
  {
    private readonly ProjectLocator _locator;

    public ParentProjectWrapper(ProjectLocator locator)
    {
      _locator = locator;
    }

    public string Locator
    {
      get { return _locator.ToString(); }
    }
  }
}
using System;
using System.Linq;
using System.Text;

namespace TeamCitySharp.DomainEntities
{
  public class Investigation
  {
    public string Id { get; set; }
    public string State { get; set; }
    public string hRef { get; set; }
    public User Assignee { get; set; }
    public InvestigationAssignment Assignment { get; set; }
    public InvestigationScope Scope { get; set; }
    public InvesigationTarget Target { get; set; }
  }
}
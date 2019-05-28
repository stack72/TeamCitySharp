using System;

namespace TeamCitySharp.Fields
{
  public class AgentsField : IField
  {
    #region Properties

    
    public bool Count { get; private set; }
    public bool NextHref { get; private set; }
    public bool PrevHref { get; private set; }
    public bool Href { get; private set; }
    public AgentField Agent { get; private set; }


    #endregion

    #region Public Methods

    public static AgentsField WithFields(
      bool count = true, 
      bool nextHref = false, 
      bool prevHref = false,
      bool href = false, 
      AgentField agent = null)
    {
      return new AgentsField
      {
        Count = count,
        NextHref = nextHref,
        PrevHref = prevHref,
        Href = href,
        Agent = agent,
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "agents"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddField(NextHref, ref currentFields, "nextHref");

      FieldHelper.AddField(PrevHref, ref currentFields, "prevHref");

      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddFieldGroup(Agent, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

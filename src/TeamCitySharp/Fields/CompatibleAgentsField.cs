using System;

namespace TeamCitySharp.Fields
{
  public class CompatibleAgentsField : IField
  {
    #region Properties

    public bool Href { get; private set; }
    public AgentField Agent { get; private set; }

    #endregion

    #region Public Methods

    public static CompatibleAgentsField WithFields(bool href = false, AgentField agent = null)
    {
      return new CompatibleAgentsField
      {
        Href = href,
        Agent = agent
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "compatibleAgents"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddFieldGroup(Agent,ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

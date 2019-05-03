using System;

namespace TeamCitySharp.Fields
{
  public class CompatibleAgentsField : IField
  {
    #region Properties

    public bool Href { get; private set; }

    #endregion

    #region Public Methods

    public static CompatibleAgentsField WithFields(bool href = false)
    {
      return new CompatibleAgentsField
      {
        Href = href
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

      return currentFields;
    }

    #endregion
  }
}

using System;

namespace TeamCitySharp.Fields
{
  public class InvestigationsField : IField
  {
    #region Properties

    public bool Href { get; private set; }

    #endregion

    #region Public Methods

    public static InvestigationsField WithFields(bool href = false)
    {
      return new InvestigationsField
      {
        Href = href
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "investigations"; }
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

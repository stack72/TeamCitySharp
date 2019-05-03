using System;

namespace TeamCitySharp.Fields
{
  public class ArtifactsField : IField
  {
    #region Properties

    public bool Href { get; private set; }

    #endregion

    #region Public Methods

    public static ArtifactsField WithFields(bool href = false)
    {
      return new ArtifactsField
      {
        Href = href
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "artifacts"; }
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

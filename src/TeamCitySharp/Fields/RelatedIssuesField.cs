using System;

namespace TeamCitySharp.Fields
{
  public class RelatedIssuesField : IField
  {
    #region Properties

    public bool Href { get; private set; }

    #endregion

    #region Public Methods

    public static RelatedIssuesField WithFields(bool href = false)
    {
      return new RelatedIssuesField
      {
        Href = href
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "relatedIssues"; }
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

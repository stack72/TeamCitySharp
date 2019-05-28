using System;

namespace TeamCitySharp.Fields
{
  public class LinksField : IField
  {
    #region Properties

    public LinkField Link { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static LinksField WithFields(LinkField link = null,
                                       bool count = true)
    {
      return new LinksField
        {
          Link = link,
          Count = count,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "links"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(Link, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

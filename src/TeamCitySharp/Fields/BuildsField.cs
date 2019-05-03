using System;
using System.Runtime.InteropServices;

namespace TeamCitySharp.Fields
{
  public class BuildsField : IField
  {
    #region Properties

    public BuildField BuildField { get; private set; }
    public bool Count { get; private set; }
    public bool Href { get; private set; }
    #endregion

    #region Public Methods

    public static BuildsField WithFields(BuildField buildField = null,
                                         bool count = true, bool href = false)
    {
      return new BuildsField
        {
          BuildField = buildField,
          Count = count,
          Href = href
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "builds"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddFieldGroup(BuildField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
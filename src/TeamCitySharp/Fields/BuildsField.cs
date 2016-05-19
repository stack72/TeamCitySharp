using System;

namespace TeamCitySharp.Fields
{
  public class BuildsField : IField
  {
    #region Properties

    public BuildField BuildField { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static BuildsField WithFields(BuildField buildField = null,
                                         bool count = true)
    {
      return new BuildsField
        {
          BuildField = buildField,
          Count = count,
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

      FieldHelper.AddFieldGroup(BuildField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
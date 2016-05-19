using System;

namespace TeamCitySharp.Fields
{
  public class BuildSnapshotDepenciesField : IField
  {
    #region Properties

    public BuildField BuildField { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static BuildSnapshotDepenciesField WithFields(BuildField buildField = null,
                                                         bool count = true)
    {
      return new BuildSnapshotDepenciesField
        {
          BuildField = buildField,
          Count = count,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "snapshot-dependencies"; }
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
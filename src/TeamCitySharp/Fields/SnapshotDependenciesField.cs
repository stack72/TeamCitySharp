using System;

namespace TeamCitySharp.Fields
{
  public class SnapshotDependenciesField : IField
  {
    #region Properties

    public bool Count { get; private set; }
    public SnapshotDependencyField SnapshotDependency { get; private set; }

    #endregion

    #region Public Methods

    public static SnapshotDependenciesField WithFields(SnapshotDependencyField snapshotDependency = null,
                                                 bool count = true)
    {
      return new SnapshotDependenciesField
      {
        SnapshotDependency = snapshotDependency,
        Count = count
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

      FieldHelper.AddFieldGroup(SnapshotDependency, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
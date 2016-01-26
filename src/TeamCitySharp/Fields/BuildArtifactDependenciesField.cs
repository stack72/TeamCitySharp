using System;

namespace TeamCitySharp.Fields
{
  public class BuildArtifactDependenciesField : IField
  {
    #region Properties

    public BuildField BuildField { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static BuildArtifactDependenciesField WithFields(BuildField buildField = null,
                                                            bool count = true)
    {
      return new BuildArtifactDependenciesField
        {
          BuildField = buildField,
          Count = count,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "artifact-dependencies"; }
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
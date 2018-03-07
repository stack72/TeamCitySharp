using System;

namespace TeamCitySharp.Fields
{
  public class ArtifactDependenciesField : IField
  {
    #region Properties

    public bool Count { get; private set; }
    public ArtifactDependencyField ArtifactDependency { get; private set; }

    #endregion

    #region Public Methods

    public static ArtifactDependenciesField WithFields(ArtifactDependencyField artifactDependency = null,
                                                 bool count = true)
    {
      return new ArtifactDependenciesField
      {
        ArtifactDependency = artifactDependency,
        Count = count
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

      FieldHelper.AddFieldGroup(ArtifactDependency, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
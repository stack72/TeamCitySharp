using System;

namespace TeamCitySharp.Fields
{
  public class ArtifactDependencyField : IField
  {
    #region Properties

    public SourceBuildTypeField SourceBuildType { get; private set; }
    public PropertiesField Properties { get; private set; }
    public bool Id { get; private set; }
    public bool Type { get; private set; }

    #endregion

    #region Public Methods

    public static ArtifactDependencyField WithFields(SourceBuildTypeField sourceBuildType = null,
      PropertiesField properties = null,
      bool id = false,
      bool type = false)
    {
      return new ArtifactDependencyField
      {
        SourceBuildType = sourceBuildType,
        Properties = properties,
        Id = id,
        Type = type,
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "artifact-dependency"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Type, ref currentFields, "type");

      FieldHelper.AddFieldGroup(SourceBuildType, ref currentFields);
      FieldHelper.AddFieldGroup(Properties, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
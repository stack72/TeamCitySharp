using System;

namespace TeamCitySharp.Fields
{
  public class ProblemScopeField : IField
  {
    #region Properties

    public ProjectField Project { get; private set; }
    public BuildTypeWrapperField BuildTypes { get; private set; }
    public BuildTypeField BuildType { get; private set; }


    #endregion

    #region Public Methods

    public static ProblemScopeField WithFields(
      ProjectField project = null, 
      BuildTypeWrapperField buildTypes = null, 
      BuildTypeField buildType = null)
    {
      return new ProblemScopeField
      {
        Project = project,
        BuildTypes= buildTypes,
        BuildType = buildType
      };
    }

    #endregion
    #region Overrides IField

    public string FieldId
    {
      get { return "ProblemScope"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddFieldGroup(Project, ref currentFields);
      FieldHelper.AddFieldGroup(BuildTypes, ref currentFields);
      FieldHelper.AddFieldGroup(BuildType, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

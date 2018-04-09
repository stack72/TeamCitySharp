using System;

namespace TeamCitySharp.Fields
{
  public class ProjectFeaturesField : IField
  {
    #region Properties

    public ProjectFeatureField ProjectFeature { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static ProjectFeaturesField WithFields(ProjectFeatureField projectFeature = null, bool count = true)
    {
      return new ProjectFeaturesField
      {
        ProjectFeature = projectFeature,
          Count = count
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "projectFeatures"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");
      FieldHelper.AddFieldGroup(ProjectFeature, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
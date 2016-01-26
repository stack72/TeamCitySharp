using System;

namespace TeamCitySharp.Fields
{
  public class BuildTypeWrapperField : IField
  {
    #region Properties

    public BuildTypeField BuildType { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static BuildTypeWrapperField WithFields(BuildTypeField buildType = null,
                                                   bool count = true)
    {
      return new BuildTypeWrapperField
        {
          BuildType = buildType,
          Count = count
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "buildTypes"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");
      FieldHelper.AddFieldGroup(BuildType, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
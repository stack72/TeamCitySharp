using System;

namespace TeamCitySharp.Fields
{
  public class BuildStepsField : IField
  {
    #region Properties

    public BuildStepField BuildStep { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static BuildStepsField WithFields(BuildStepField buildStep = null,
                                             bool count = true)
    {
      return new BuildStepsField
        {
          BuildStep = buildStep,
          Count = count,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "steps"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(BuildStep, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
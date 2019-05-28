using System;

namespace TeamCitySharp.Fields
{
  public class ProgressInfoField : IField
  {
    #region Properties


    public bool PercentageComplete { get; private set; }
    public bool ElapsedSeconds { get; private set; }
    public bool EstimatedTotalSeconds { get; private set; }
    public bool LeftSeconds { get; private set; }
    public bool CurrentStageText { get; private set; }
    public bool Outdated { get; private set; }
    public bool ProbablyHanging { get; private set; }
    public bool LastActivityTime { get; private set; }




    public bool Text { get; private set; }
    public UserField User { get; private set; }

    #endregion

    #region Public Methods

    public static ProgressInfoField WithFields(
      bool percentageComplete = true, 
      bool elapsedSeconds = false,
      bool estimatedTotalSeconds = false, 
      bool leftSeconds = false, 
      bool currentStageText = false,
      bool outdated = false,
      bool probablyHanging = false,
      bool lastActivityTime = false,
      UserField user = null)
    {
      return new ProgressInfoField
      {
        PercentageComplete = percentageComplete,
        ElapsedSeconds = elapsedSeconds,
        EstimatedTotalSeconds = estimatedTotalSeconds,
        LeftSeconds = leftSeconds,
        CurrentStageText = currentStageText,
        Outdated = outdated,
        ProbablyHanging = probablyHanging,
        LastActivityTime = lastActivityTime,
        User = user,
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "progress-info"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(PercentageComplete, ref currentFields, "percentageComplete");
      FieldHelper.AddField(ElapsedSeconds, ref currentFields, "elapsedSeconds");
      FieldHelper.AddField(EstimatedTotalSeconds, ref currentFields, "estimatedTotalSeconds");
      FieldHelper.AddField(LeftSeconds, ref currentFields, "leftSeconds");
      FieldHelper.AddField(CurrentStageText, ref currentFields, "currentStageText");
      FieldHelper.AddField(Outdated, ref currentFields, "outdated");
      FieldHelper.AddField(ProbablyHanging, ref currentFields, "probablyHanging");
      FieldHelper.AddField(LastActivityTime, ref currentFields, "lastActivityTime");
      FieldHelper.AddField(PercentageComplete, ref currentFields, "percentageComplete");

      FieldHelper.AddFieldGroup(User, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
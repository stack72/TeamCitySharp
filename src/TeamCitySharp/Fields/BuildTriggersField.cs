using System;

namespace TeamCitySharp.Fields
{
  public class BuildTriggersField : IField
  {
    #region Properties

    public BuildTriggerField BuildTrigger { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static BuildTriggersField WithFields(BuildTriggerField buildTrigger = null,
                                                bool count = true)
    {
      return new BuildTriggersField
        {
          BuildTrigger = buildTrigger,
          Count = count,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "triggers"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(BuildTrigger, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
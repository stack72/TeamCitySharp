using System;

namespace TeamCitySharp.Fields
{
  public class BuildChangesField : IField
  {
    #region Properties

    
    public bool Count { get; private set; }
    public BuildChangeField BuildChange { get; private set; }
    #endregion

    #region Public Methods

    public static BuildChangesField WithFields(bool count = true, BuildChangeField buildChange=null )
    {
      return new BuildChangesField
      {
        Count = count,
        BuildChange = buildChange
      };
    }

    #endregion

    #region Overrides IField
    public string FieldId
    {
      get { return "buildChanges"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(BuildChange, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

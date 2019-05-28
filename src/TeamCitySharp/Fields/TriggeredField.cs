using System;

namespace TeamCitySharp.Fields
{
  public class TriggeredField : IField
  {
    #region Properties
    // Fields
    public bool Type { get; private set; }
    public bool Details { get; private set; }
    public bool Date { get; private set; }
    public bool DisplayText { get; private set; }
    public bool RawValue { get; private set; }
    // Group fields
    public UserField User { get; private set; }
    public BuildField Build { get; private set; }
    public BuildTypeField BuildType { get; private set; }
    public PropertiesField Properties { get; private set; }

    #endregion

    #region Public Methods

    public static TriggeredField WithFields(
      // Fields
      bool type = false,
      bool date = false,
      bool details= false,
      bool displayText= false,
      bool rawValue = false,
      // Group Fields
      BuildTypeField buildType = null,
      UserField user = null,
      BuildField build =null,
      PropertiesField properties=null)
    {
      return new TriggeredField
      {
        // Fields
        Type = type,
        Details = details,
        Date = date,
        DisplayText = displayText,
        RawValue = rawValue,
        // Group fields
        User = user,
        Build = build,
        BuildType = buildType,
        Properties = properties
      };
    }

    #endregion
    #region Overrides IField

    public string FieldId
    {
      get { return "triggered"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Type, ref currentFields, "type");
      FieldHelper.AddField(Details, ref currentFields, "details");
      FieldHelper.AddField(Date, ref currentFields, "date");
      FieldHelper.AddField(DisplayText, ref currentFields, "displayText");
      FieldHelper.AddField(RawValue, ref currentFields, "rawValue");

      FieldHelper.AddFieldGroup(User, ref currentFields);
      FieldHelper.AddFieldGroup(Build, ref currentFields);
      FieldHelper.AddFieldGroup(BuildType, ref currentFields);
      FieldHelper.AddFieldGroup(Properties, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

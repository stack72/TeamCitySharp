using System;

namespace TeamCitySharp.Fields
{
  public class TriggeredField : IField
  {
    #region Properties
    public bool Type { get; private set; }
    public bool Date { get; private set; }
    public bool Details { get; private set; }
    public BuildTypeField BuildTypeField { get; private set; }
    public UserField UserField { get; private set; }
    #endregion

    #region Public Methods

    public static TriggeredField WithFields(bool type = false, bool date = false,bool details= false, BuildTypeField buildTypeField = null, UserField userField = null)
    {
      return new TriggeredField
      {
        Type = type,
        Date = date,
        Details = details,
        BuildTypeField = buildTypeField,
        UserField = userField
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
      FieldHelper.AddField(Date, ref currentFields, "date");
      FieldHelper.AddField(Details, ref currentFields, "details");

      FieldHelper.AddFieldGroup(BuildTypeField, ref currentFields);
      FieldHelper.AddFieldGroup(UserField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

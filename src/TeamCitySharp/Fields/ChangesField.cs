using System;

namespace TeamCitySharp.Fields
{
  public class ChangesField : IField
  {
    #region Properties

    public ChangeField ChangeField { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static ChangesField WithFields(ChangeField changeField = null,
                                         bool count = true)
    {
      return new ChangesField
      {
        ChangeField = changeField,
        Count = count,
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "changes"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(ChangeField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

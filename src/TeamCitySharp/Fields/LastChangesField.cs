using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.Fields
{
  public class LastChangesField : IField
  {
    #region Properties

    public ChangeField ChangeField { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static LastChangesField WithFields(ChangeField changeField = null, bool count = true)
    {
      return new LastChangesField
        {
          ChangeField = changeField,
          Count = count
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "lastChanges"; }
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

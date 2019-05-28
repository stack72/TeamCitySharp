using System;

namespace TeamCitySharp.Fields
{
  public class EntryField : IField
  {
    #region Properties

    public bool Name { get; private set; }
    public bool Value { get; private set; }

    #endregion

    #region Public Methods

    public static EntryField WithFields(bool name = false, bool value = false )
    {
      return new EntryField
      {
          Name = name,
          Value = value
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "entry"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Name, ref currentFields, "name");
      FieldHelper.AddField(Value, ref currentFields, "value");
      return currentFields;
    }

    #endregion
  }
}
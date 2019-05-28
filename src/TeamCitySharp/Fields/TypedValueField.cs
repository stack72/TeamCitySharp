using System;

namespace TeamCitySharp.Fields
{
  public class TypedValueField : IField
  {
    #region Properties

    public bool Name { get; private set; }
    public bool Type { get; private set; }
    public bool Value { get; private set; }

    #endregion

    #region Public Methods

    public static TypedValueField WithFields(
      bool name = false,
      bool type = false,
      bool value = false)
    {
      return new TypedValueField
      {
          Name = name,
          Type = type,
          Value = value
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "typedValue"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Name, ref currentFields, "name");
      FieldHelper.AddField(Type, ref currentFields, "type");
      FieldHelper.AddField(Value, ref currentFields, "value");

      return currentFields;
    }

    #endregion
  }
}
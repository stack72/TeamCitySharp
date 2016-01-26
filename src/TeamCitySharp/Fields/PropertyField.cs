using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.Fields
{
  public class PropertyField : IField
  {
    public bool Name { get; private set; }
    public bool Value { get; private set; }

    public static PropertyField WithFields(bool name = false, bool value = false)
    {
      return new PropertyField
        {
          Name = name,
          Value = value,
        };
    }

    public string FieldId
    {
      get { return "property"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Name, ref currentFields, "name");
      FieldHelper.AddField(Value, ref currentFields, "value");
      return currentFields;
    }
  }
}
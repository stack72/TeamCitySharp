using System;

namespace TeamCitySharp.Fields
{
  public class PropertiesField : IField
  {
    public PropertyField PropertyField { get; private set; }
    public bool Count { get; private set; }


    public static PropertiesField WithFields(PropertyField propertyField = null,
                                             bool count = true)
    {
      return new PropertiesField
        {
          PropertyField = propertyField,
          Count = count,
        };
    }

    public string FieldId
    {
      get { return "properties"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");
      FieldHelper.AddFieldGroup(PropertyField, ref currentFields);


      return currentFields;
    }
  }
}
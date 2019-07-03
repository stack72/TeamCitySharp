using System;

namespace TeamCitySharp.Fields
{
  public class PropertiesField : IField
  {
    public PropertyField PropertyField { get; private set; }
    public bool Count { get; private set; }
    public bool Href { get; private set; }


    public static PropertiesField WithFields(PropertyField propertyField = null,
                                             bool count = true,
                                             bool href= false)
    {
      return new PropertiesField
        {
          PropertyField = propertyField,
          Count = count,
          Href = href
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
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddFieldGroup(PropertyField, ref currentFields);


      return currentFields;
    }
  }
}
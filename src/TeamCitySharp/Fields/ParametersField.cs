using System;

namespace TeamCitySharp.Fields
{
  public class ParametersField : IField
  {
    #region Properties

    public bool Count { get; private set; }
    public PropertyField Property { get; private set; }
    public bool Href { get; private set; }

    #endregion

    #region Public Methods

    public static ParametersField WithFields(PropertyField property = null,
                                             bool count = true,
                                             bool href = false)
    {
      return new ParametersField
        {
          Property = property,
          Count = count,
          Href = href
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "parameters"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");
      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddFieldGroup(Property, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
using System;

namespace TeamCitySharp.Fields
{
  public class StatisticsField : IField
  {
    #region Properties

    public PropertiesField PropertiesField { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static StatisticsField WithFields(PropertiesField propertiesField = null,
                                             bool count = true)
    {
      return new StatisticsField
        {
          PropertiesField = propertiesField,
          Count = count,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "statistics"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(PropertiesField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
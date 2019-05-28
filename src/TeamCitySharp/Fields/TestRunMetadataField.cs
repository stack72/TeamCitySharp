using System;

namespace TeamCitySharp.Fields
{
  public class TestRunMetadataField : IField
  {
    #region Properties

    public bool Count { get; private set; }
    public TypedValueField TypedValue { get; private set; }

    #endregion

    #region Public Methods

    public static TestRunMetadataField WithFields(bool count = true, TypedValueField typedValue = null)
    {
      return new TestRunMetadataField
      {
          Count = count,
          TypedValue = typedValue
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "testRunMetadata"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");
      FieldHelper.AddFieldGroup(TypedValue, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
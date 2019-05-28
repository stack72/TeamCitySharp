using System;

namespace TeamCitySharp.Fields
{
  public class DatasField : IField
  {
    #region Properties

    public MetaDataField Data { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static DatasField WithFields(
      bool count = true,
      MetaDataField data = null
      )
    {
      return new DatasField
      {
        Count = count,
        Data = data

      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "datas"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(Data, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

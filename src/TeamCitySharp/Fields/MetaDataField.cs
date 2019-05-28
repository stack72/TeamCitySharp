using System;

namespace TeamCitySharp.Fields
{
  public class MetaDataField : IField
  {
    #region Properties

    public bool Id { get; private set; }
    public EntriesField Entries { get; private set; }

    #endregion

    #region Public Methods

    public static MetaDataField WithFields(bool id = false, EntriesField entries = null )
    {
      return new MetaDataField
      {
          Id = id,
          Entries = entries
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "metaData"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddFieldGroup(Entries, ref currentFields);
      return currentFields;
    }

    #endregion
  }
}
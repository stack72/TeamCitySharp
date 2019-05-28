using System;

namespace TeamCitySharp.Fields
{
  public class EntriesField : IField
  {
    #region Properties

    public EntryField Entry { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static EntriesField WithFields(
      bool count = true,
      EntryField entry = null
      )
    {
      return new EntriesField
      {
        Entry = entry,
        Count = count
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "entries"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(Entry, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

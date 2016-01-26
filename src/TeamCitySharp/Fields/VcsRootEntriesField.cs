using System;

namespace TeamCitySharp.Fields
{
  public class VcsRootEntriesField : IField
  {
    #region Properties

    public bool Count { get; private set; }
    public VcsRootEntryField VcsRootEntry { get; private set; }

    #endregion

    #region Public Methods

    public static VcsRootEntriesField WithFields(VcsRootEntryField vcsRootEntry = null,
                                                 bool count = true)
    {
      return new VcsRootEntriesField
        {
          VcsRootEntry = vcsRootEntry,
          Count = count
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "vcs-root-entries"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(VcsRootEntry, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
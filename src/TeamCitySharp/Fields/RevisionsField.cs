using System;

namespace TeamCitySharp.Fields
{
  public class RevisionsField : IField
  {
    #region Properties

    public bool Count { get; private set; }
    public RevisionField RevisionField { get; private set; }

    #endregion

    #region Public Methods

    public static RevisionsField WithFields(RevisionField revisionField = null,
                                             bool count = true)
    {
      return new RevisionsField
      {
        RevisionField = revisionField,
        Count = count
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "revisions"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(RevisionField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

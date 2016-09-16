using System;

namespace TeamCitySharp.Fields
{
  public class RevisionField : IField
  {
    #region Properties
    public bool Version { get; private set; }
    public VcsRootInstanceField VcsRootInstanceField { get; private set; }
    #endregion

    #region Public Methods
    public static RevisionField WithFields(bool version = false, VcsRootInstanceField vcsRootInstanceField = null)
    {
      return new RevisionField
      {
        Version = version,
        VcsRootInstanceField = vcsRootInstanceField
      };
    }

    #endregion
    #region Overrides IField

    public string FieldId
    {
      get { return "revision"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Version, ref currentFields, "version");

      FieldHelper.AddFieldGroup(VcsRootInstanceField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

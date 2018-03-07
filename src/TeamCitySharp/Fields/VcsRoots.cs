using System;

namespace TeamCitySharp.Fields
{
  public class VcsRootsField : IField
  {
    #region Properties

    public bool Count { get; private set; }
    public VcsRootField VcsRoot { get; private set; }

    #endregion

    #region Public Methods

    public static VcsRootsField WithFields(VcsRootField vcsRoot = null,
                                                 bool count = true)
    {
      return new VcsRootsField
        {
          VcsRoot = vcsRoot,
          Count = count
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "vcs-roots"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(VcsRoot, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
using System;

namespace TeamCitySharp.Fields
{
  public class VcsRootEntryField : IField
  {
    #region Properties

    public VcsRootField VcsRoot { get; private set; }
    public bool Id { get; private set; }
    public bool CheckoutRules { get; private set; }

    #endregion

    #region Public Methods

    public static VcsRootEntryField WithFields(VcsRootField vcsRoot = null,
                                               bool id = false,
                                               bool checkoutRules = false)
    {
      return new VcsRootEntryField
        {
          VcsRoot = vcsRoot,
          Id = id,
          CheckoutRules = checkoutRules,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "vcs-root-entry"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(CheckoutRules, ref currentFields, "checkout-rules");

      FieldHelper.AddFieldGroup(VcsRoot, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
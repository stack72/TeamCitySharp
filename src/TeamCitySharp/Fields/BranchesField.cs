using System;

namespace TeamCitySharp.Fields
{
  public class BranchesField : IField
  {
    #region Properties

    
    public bool Count { get; private set; }
    public bool Href { get; private set; }
    public BranchField Branch { get; private set; }


    #endregion

    #region Public Methods

    public static BranchesField WithFields(
      bool count = true,
      bool href = false, 
      BranchField branch = null)
    {
      return new BranchesField
      {
        Count = count,

        Href = href,
        Branch = branch,
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "branches"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddFieldGroup(Branch, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

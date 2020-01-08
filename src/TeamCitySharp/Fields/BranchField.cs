using System;

namespace TeamCitySharp.Fields
{
  public class BranchField : IField
  {
    #region Properties

    public bool Name { get; private set; }
    public bool Default { get; private set; }
    public bool LastActivity { get; private set; }
    public bool Active { get; private set; }

    #endregion

    #region Public Methods

    public static BranchField WithFields(bool name = false,
                                        bool defaultValue = false, 
                                        bool lastActivity = false,
                                        bool active = false)
    {
      return new BranchField
      { 
        Name = name,
        Default = defaultValue,
        LastActivity = lastActivity,
        Active = active
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "branch"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;


      FieldHelper.AddField(Name, ref currentFields, "name");

      FieldHelper.AddField(Default, ref currentFields, "default");

      FieldHelper.AddField(LastActivity, ref currentFields, "lastActivity");

      FieldHelper.AddField(Active, ref currentFields, "active");

      return currentFields;
    }

    #endregion
  }
}
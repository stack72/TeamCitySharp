using System;

namespace TeamCitySharp.Fields
{
  public class BuildChangeField : IField
  {
    #region Properties

    public BuildField NextBuild { get; private set; }
    public BuildField PrevBuild { get; private set; }
    #endregion

    #region Public Methods

    public static BuildChangeField WithFields(BuildField nextBuild = null, BuildField prevBuild = null )
    {
      return new BuildChangeField
      {
        NextBuild = nextBuild,
        PrevBuild = prevBuild
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "buildChange"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddFieldGroup(NextBuild, ref currentFields, "nextBuild");
      FieldHelper.AddFieldGroup(PrevBuild, ref currentFields, "prevBuild");

      return currentFields;
    }

    #endregion
  }
}

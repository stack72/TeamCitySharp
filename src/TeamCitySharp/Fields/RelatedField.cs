using System;

namespace TeamCitySharp.Fields
{
  public class RelatedField : IField
  {
    #region Properties

    public BuildsField Builds { get; private set; }

    #endregion

    #region Public Methods

    public static RelatedField WithFields(BuildsField builds = null)
    {
      return new RelatedField
      {
          Builds = builds,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "related"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddFieldGroup(Builds, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

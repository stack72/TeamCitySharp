using System;

namespace TeamCitySharp.Fields
{
  public class ProjectFeatureField : IField
  {
    #region Properties

    public bool Id { get; private set; }
    public bool Href { get; private set; }
    public bool Type { get; private set; }
    public PropertiesField Properties { get; private set; }

    #endregion

    #region Public Methods

    public static ProjectFeatureField WithFields(bool id = false,
      bool type = false,
      bool href = false,
      PropertiesField properties = null)
    {
      return new ProjectFeatureField
      {
        Id = id,
        Type = type,
        Href = href,
        Properties = properties
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "projectFeature"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(Type, ref currentFields, "type");
      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddFieldGroup(Properties, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
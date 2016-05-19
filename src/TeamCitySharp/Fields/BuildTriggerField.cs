using System;

namespace TeamCitySharp.Fields
{
  public class BuildTriggerField : IField
  {
    #region Properties

    public PropertiesField Properties { get; private set; }
    public bool Id { get; private set; }
    public bool Type { get; private set; }

    #endregion

    #region Public Methods

    public static BuildTriggerField WithFields(PropertiesField properties = null,
                                               bool id = false,
                                               bool type = false)
    {
      return new BuildTriggerField
        {
          Properties = properties,
          Id = id,
          Type = type
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "trigger"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Type, ref currentFields, "type");

      FieldHelper.AddFieldGroup(Properties, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
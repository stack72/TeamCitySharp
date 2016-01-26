using System;

namespace TeamCitySharp.Fields
{
  public class BuildStepField : IField
  {
    #region Properties

    public PropertiesField Properties { get; private set; }
    public bool Id { get; private set; }
    public bool Name { get; private set; }
    public bool Type { get; private set; }
    public bool Disabled { get; private set; }

    #endregion

    #region Public Methods

    public static BuildStepField WithFields(PropertiesField properties = null,
                                            bool id = false,
                                            bool name = false,
                                            bool type = false,
                                            bool disabled = false)
    {
      return new BuildStepField
        {
          Properties = properties,
          Id = id,
          Name = name,
          Type = type,
          Disabled = disabled
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "step"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Name, ref currentFields, "name");
      FieldHelper.AddField(Type, ref currentFields, "type");
      FieldHelper.AddField(Disabled, ref currentFields, "disabled");

      FieldHelper.AddFieldGroup(Properties, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
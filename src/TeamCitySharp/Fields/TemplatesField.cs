using System;

namespace TeamCitySharp.Fields
{
  public class TemplatesField : IField
  {
    #region Properties

    public TemplateField Template { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static TemplatesField WithFields(TemplateField template = null,
                                            bool count = true)
    {
      return new TemplatesField
        {
          Template = template,
          Count = count
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "templates"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");
      FieldHelper.AddFieldGroup(Template, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
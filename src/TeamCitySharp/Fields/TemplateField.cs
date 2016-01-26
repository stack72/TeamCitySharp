using System;

namespace TeamCitySharp.Fields
{
  public class TemplateField : IField
  {
    #region Properties

    public bool Id { get; private set; }
    public bool Name { get; private set; }
    public bool Href { get; private set; }
    public bool ProjectId { get; private set; }
    public bool ProjectName { get; private set; }

    #endregion

    #region Public Methods

    public static TemplateField WithFields(bool id = false,
                                           bool name = false,
                                           bool href = false,
                                           bool projectId = false,
                                           bool projectName = false)
    {
      return new TemplateField
        {
          Id = id,
          Name = name,
          Href = href,
          ProjectId = projectId,
          ProjectName = projectName
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "template"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(ProjectName, ref currentFields, "projectName");
      FieldHelper.AddField(ProjectId, ref currentFields, "projectId");
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(Name, ref currentFields, "name");
      FieldHelper.AddField(Id, ref currentFields, "id");

      return currentFields;
    }

    #endregion
  }
}
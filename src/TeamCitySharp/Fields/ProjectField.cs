using System;

namespace TeamCitySharp.Fields
{
  public class ProjectField : IField
  {
    #region Properties

    public bool Archived { get; private set; }
    public bool Description { get; private set; }
    public bool Href { get; private set; }
    public bool Id { get; private set; }
    public bool Name { get; private set; }
    public bool WebUrl { get; private set; }

    public ParentProjectField ParentProject { get; private set; }
    public BuildTypeWrapperField BuildTypeWrapper { get; private set; }
    public ParametersField Parameters { get; private set; }
    public TemplatesField Templates { get; private set; }
    public ProjectWrapperField ProjectWrapper { get; private set; }

    #endregion

    #region Public Methods

    public static ProjectField WithFields(bool archived = false,
                                          bool description = false,
                                          bool href = false,
                                          bool id = false,
                                          bool name = false,
                                          bool webUrl = false,
                                          ParametersField parameters = null,
                                          ParentProjectField parentProject = null,
                                          BuildTypeWrapperField buildTypeWrapper = null,
                                          TemplatesField templates = null,
                                          ProjectWrapperField projectWrapper = null)
    {
      return new ProjectField
        {
          Archived = archived,
          Description = description,
          Href = href,
          Id = id,
          Name = name,
          WebUrl = webUrl,
          Parameters = parameters,
          ParentProject = parentProject,
          BuildTypeWrapper = buildTypeWrapper,
          Templates = templates,
          ProjectWrapper = projectWrapper
        };
    }

    #endregion

    #region Overwrides IField

    public string FieldId
    {
      get { return "project"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Archived, ref currentFields, "archived");
      FieldHelper.AddField(Description, ref currentFields, "description");
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Name, ref currentFields, "name");

      FieldHelper.AddFieldGroup(ParentProject, ref currentFields);
      FieldHelper.AddFieldGroup(Parameters, ref currentFields);
      FieldHelper.AddFieldGroup(BuildTypeWrapper, ref currentFields);
      FieldHelper.AddFieldGroup(Templates, ref currentFields);
      FieldHelper.AddFieldGroup(ProjectWrapper, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
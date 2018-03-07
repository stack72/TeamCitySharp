using System;

namespace TeamCitySharp.Fields
{
  public class SourceBuildTypeField : IField
  {
    #region Properties

    public bool Id { get; private set; }
    public bool Name { get; private set; }
    public bool Number { get; private set; }
    public bool Status { get; private set; }
    public bool Href { get; private set; }
    public bool ProjectId { get; private set; }
    public bool ProjectName { get; private set; }
    public bool Description { get; private set; }
    public bool WebUrl { get; private set; }
    public bool Personal { get; private set; }
    public bool History { get; private set; }
    public bool Cancelled { get; private set; }
    public bool Pinned { get; private set; }
    public bool Running { get; private set; }

    public ProjectField Project { get; private set; }
    public TemplateField Template { get; private set; }
    public ParametersField Parameters { get; private set; }
    public BuildStepsField BuildSteps { get; private set; }
    public BuildTriggersField Triggers { get; set; }
    public VcsRootEntriesField VcsRootEntries { get; set; }
    public ArtifactDependenciesField ArtifactDependencies { get; set; }
    public SnapshotDependenciesField SnapshotDependencies { get; set; }
   

    #endregion

    #region Public Methods

    public static SourceBuildTypeField WithFields(bool id = false,
                                            bool name = false,
                                            bool number = false,
                                            bool status = false,
                                            bool href = false,
                                            bool projectId = false,
                                            bool projectName = false,
                                            bool description = false,
                                            bool webUrl = false,
                                            bool personal = false,
                                            bool history = false,
                                            bool cancelled = false,
                                            bool pinned = false,
                                            bool running = false,
                                            ProjectField project = null,
                                            TemplateField template = null,
                                            ParametersField parameters = null,
                                            BuildStepsField buildSteps = null,
                                            BuildTriggersField triggers = null,
                                            VcsRootEntriesField vcsRootEntries = null,
                                            ArtifactDependenciesField artifactDependencies = null,
                                            SnapshotDependenciesField snapshotDependencies = null)
    {
      return new SourceBuildTypeField
      {
          Running = running,
          Pinned = pinned,
          History = history,
          Cancelled = cancelled,
          Personal = personal,
          WebUrl = webUrl,
          Description = description,
          ProjectName = projectName,
          ProjectId = projectId,
          Href = href,
          Status = status,
          Number = number,
          Name = name,
          Id = id,
          Project = project,
          Template = template,
          Parameters = parameters,
          BuildSteps = buildSteps,
          Triggers = triggers,
          VcsRootEntries = vcsRootEntries,
          ArtifactDependencies = artifactDependencies,
          SnapshotDependencies = snapshotDependencies
          
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "source-buildType"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Running, ref currentFields, "running");
      FieldHelper.AddField(Pinned, ref currentFields, "pinned");
      FieldHelper.AddField(History, ref currentFields, "history");
      FieldHelper.AddField(Cancelled, ref currentFields, "cancelled");
      FieldHelper.AddField(Personal, ref currentFields, "personal");
      FieldHelper.AddField(WebUrl, ref currentFields, "webUrl");
      FieldHelper.AddField(Description, ref currentFields, "description");
      FieldHelper.AddField(ProjectName, ref currentFields, "projectName");
      FieldHelper.AddField(ProjectId, ref currentFields, "projectId");
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(Status, ref currentFields, "status");
      FieldHelper.AddField(Number, ref currentFields, "number");
      FieldHelper.AddField(Name, ref currentFields, "name");
      FieldHelper.AddField(Id, ref currentFields, "id");

      FieldHelper.AddFieldGroup(Project, ref currentFields);
      FieldHelper.AddFieldGroup(Template, ref currentFields);
      FieldHelper.AddFieldGroup(Parameters, ref currentFields);
      FieldHelper.AddFieldGroup(BuildSteps, ref currentFields);
      FieldHelper.AddFieldGroup(Triggers, ref currentFields);
      FieldHelper.AddFieldGroup(VcsRootEntries, ref currentFields);
      FieldHelper.AddFieldGroup(ArtifactDependencies, ref currentFields);
      FieldHelper.AddFieldGroup(SnapshotDependencies, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
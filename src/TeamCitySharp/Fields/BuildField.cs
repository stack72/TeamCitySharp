using System;

namespace TeamCitySharp.Fields
{
  public class BuildField : IField
  {
    #region Properties

    public bool Id { get; private set; }
    public bool Number { get; private set; }
    public bool Status { get; private set; }
    public bool BuildTypeId { get; private set; }
    public bool Href { get; private set; }
    public bool WebUrl { get; private set; }
    public bool StatusText { get; private set; }
    public bool StartDate { get; private set; }
    public bool FinishDate { get; private set; }
    public bool QueuedDate { get; private set; }
    public bool State { get; private set; }
    public bool Personal { get; private set; }

    public BuildTypeField BuildType { get; private set; }
    public AgentField Agent { get; private set; }
    public TagsField Tags { get; private set; }
    public LastChangesField LastChanges { get; private set; }
    public TriggeredField Triggered { get; set; }
    public PropertiesField Properties { get; private set; }
    public BuildSnapshotDepenciesField SnapshotDependencies { get; private set; }
    public BuildArtifactDependenciesField ArtifactDependencies { get; private set; }
    public RevisionsField Revisions { get; private set; }
    public ChangesField Changes { get; private set; }

    #endregion

    #region Public Methods

    public static BuildField WithFields(bool id = false,
                                        bool number = false,
                                        bool status = false,
                                        bool buildTypeId = false,
                                        bool href = false,
                                        bool webUrl = false,
                                        bool statusText = false,
                                        bool startDate = false,
                                        bool finishDate = false,
                                        bool queuedDate = false,
                                        bool state = false,
                                        bool personal = false,
                                        BuildTypeField buildType = null,
                                        AgentField agent = null,
                                        TagsField tags = null,
                                        LastChangesField lastChanges = null, 
                                        ChangesField changes = null,
                                        TriggeredField triggered = null,
                                        RevisionsField revisions = null,
                                        PropertiesField properties = null,
                                        BuildSnapshotDepenciesField snapshotDepencies = null,
                                        BuildArtifactDependenciesField artifactDependencies = null)
    {
      return new BuildField
        {
          Id = id,
          Number = number,
          Status = status,
          BuildTypeId = buildTypeId,
          Href = href,
          WebUrl = webUrl,
          StatusText = statusText,
          StartDate = startDate,
          FinishDate = finishDate,
          QueuedDate = queuedDate,
          State = state,
          Personal = personal,
          BuildType = buildType,
          Agent = agent,
          Tags = tags,
          LastChanges = lastChanges,
          Changes = changes,
          Triggered = triggered,
          Revisions = revisions,
          Properties = properties,
          SnapshotDependencies = snapshotDepencies,
          ArtifactDependencies = artifactDependencies
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "build"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");

      FieldHelper.AddField(Number, ref currentFields, "number");

      FieldHelper.AddField(Status, ref currentFields, "status");

      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddField(WebUrl, ref currentFields, "webUrl");

      FieldHelper.AddField(StatusText, ref currentFields, "statusText");

      FieldHelper.AddField(StartDate, ref currentFields, "startDate");

      FieldHelper.AddField(FinishDate, ref currentFields, "finishDate");

      FieldHelper.AddField(QueuedDate, ref currentFields, "queuedDate");

      FieldHelper.AddField(State, ref currentFields, "state");

      FieldHelper.AddField(Personal, ref currentFields, "personal");

      FieldHelper.AddField(BuildTypeId, ref currentFields, "buildTypeId");

      FieldHelper.AddFieldGroup(Agent, ref currentFields);

      FieldHelper.AddFieldGroup(Tags, ref currentFields);

      FieldHelper.AddFieldGroup(BuildType, ref currentFields);

      FieldHelper.AddFieldGroup(LastChanges, ref currentFields);

      FieldHelper.AddFieldGroup(Changes, ref currentFields);

      FieldHelper.AddFieldGroup(Triggered, ref currentFields);

      FieldHelper.AddFieldGroup(Revisions, ref currentFields);

      FieldHelper.AddFieldGroup(Properties, ref currentFields);

      FieldHelper.AddFieldGroup(SnapshotDependencies, ref currentFields);

      FieldHelper.AddFieldGroup(ArtifactDependencies, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
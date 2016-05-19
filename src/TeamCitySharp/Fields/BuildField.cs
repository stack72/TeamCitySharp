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
    public bool State { get; private set; }

    public BuildTypeField BuildType { get; private set; }
    public AgentField Agent { get; private set; }
    /* public ChangeWrapperField Changes { get; private set; }*/
    public PropertiesField Properties { get; private set; }
    public BuildSnapshotDepenciesField SnapshotDependencies { get; private set; }
    public BuildArtifactDependenciesField ArtifactDependencies { get; private set; }

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
                                        bool state = false,
                                        BuildTypeField buildType = null,
                                        AgentField agent = null,
                                        /* ChangeWrapperField Changes = null, */
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
          State = state,
          BuildType = buildType,
          Agent = agent,
          //Changes = changes,
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

      FieldHelper.AddField(State, ref currentFields, "state");

      FieldHelper.AddField(BuildTypeId, ref currentFields, "buildTypeId");

      FieldHelper.AddFieldGroup(Agent, ref currentFields);

      FieldHelper.AddFieldGroup(BuildType, ref currentFields);

      //FieldHelper.AddField(Changes, ref currentFields, "changes");

      FieldHelper.AddFieldGroup(Properties, ref currentFields);

      FieldHelper.AddFieldGroup(SnapshotDependencies, ref currentFields);

      FieldHelper.AddFieldGroup(ArtifactDependencies, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
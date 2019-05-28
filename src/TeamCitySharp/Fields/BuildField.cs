using System;
using TeamCitySharp.ActionTypes;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.Fields
{
  public class BuildField : IField
  {
    #region Properties
    // Fields
    public bool Id { get; private set; }
    public bool TaskId { get; private set; }
    public bool BuildTypeId { get; private set; }
    public bool BuildTypeInternalId { get; private set; }
    public bool Number { get; private set; }
    public bool Status { get; private set; }
    public bool State { get; private set; }
    public bool Running { get; private set; }
    public bool Composite { get; private set; }
    public bool FailedToStart { get; private set; }
    public bool Personal { get; private set; }
    public bool PercentageComplete { get; private set; }
    public bool BranchName { get; private set; }
    public bool DefaultBranch { get; private set; }
    public bool UnspecifiedBranch { get; private set; }
    public bool History { get; private set; }
    public bool Pinned { get; private set; }
    public bool Href { get; private set; }
    public bool WebUrl { get; private set; }
    public bool QueuePosition { get; private set; }
    public bool LimitedChangesCount { get; private set; }
    public bool ArtifactsDirectory { get; private set; }
    public bool StatusText { get; private set; }
    public bool StartEstimate { get; private set; }
    public bool WaitReason { get; private set; }
    public bool QueuedDate { get; private set; }
    public bool StartDate { get; private set; }
    public bool FinishDate { get; private set; }
    public bool SettingsHash { get; private set; }
    public bool CurrentSettingsHash { get; private set; }
    public bool ModificationId { get; private set; }
    public bool ChainModificationId { get; private set; }
    public bool UsedByOtherBuilds { get; private set; }

    // Group Fields
    public LinksField Links { get; private set; }
    public BuildTypeField BuildType { get; private set; }
    public CommentField Comment { get; private set; }
    public TagsField Tags { get; private set; }
    public CommentField PinInfo { get; private set; }
    public UserField User { get; private set; }
    public ProgressInfoField Running_info { get; private set; }
    public CommentField CanceledInfo { get; private set; }
    public TriggeredField Triggered { get; set; }
    public LastChangesField LastChanges { get; private set; }
    public ChangesField Changes { get; private set; }
    public RevisionsField Revisions { get; private set; }
    public RevisionField VersionedSettingsRevision { get; private set; }
    public BuildChangesField ArtifactDependencyChanges { get; private set; }
    public AgentField Agent { get; private set; }
    public CompatibleAgentsField CompatibleAgents { get; private set; }
    public TestOccurrencesField TestOccurrences { get; private set; }
    public ProblemOccurrencesField ProblemOccurrences { get; private set; }
    public ArtifactsField Artifacts { get; private set; }
    public RelatedIssuesField RelatedIssues { get; private set; }
    public PropertiesField Properties { get; private set; }
    public PropertiesField ResultingProperties { get; private set; }
    public EntriesField Attributes { get; private set; }
    public StatisticsField Statistics { get; private set; }
    public DatasField Metadata { get; private set; }
    public BuildSnapshotDependenciesField SnapshotDependencies { get; private set; }
    public BuildArtifactDependenciesField ArtifactDependencies { get; private set; }
    public ArtifactDependenciesField CustomArtifactDependencies { get; private set; }
    public ItemsField ReplacementIds { get; private set; }
    public RelatedField Related { get; private set; }
    public CommentField StatusChangeComment { get; private set; }
    #endregion

    #region Public Methods

    public static BuildField WithFields(
      // Fields
      bool id = false,
      bool taskId = false,
      bool buildTypeId = false,
      bool buildTypeInternalId = false,
      bool number = false,
      bool status = false,
      bool state = false,
      bool running = false,
      bool composite = false, 
      bool failedToStart = false,
      bool personal = false,
      bool percentageComplete = false,
      bool branchName = false,
      bool defaultBranch = false,
      bool unspecifiedBranch = false,
      bool history = false,
      bool pinned = false,
      bool href = false,
      bool webUrl = false,
      bool queuePosition = false,
      bool limitedChangesCount = false,
      bool artifactsDirectory = false,
      bool statusText = false,
      bool startEstimate = false,
      bool waitReason = false,
      bool startDate = false,
      bool finishDate = false,
      bool queuedDate = false,
      bool settingsHash = false,
      bool currentSettingsHash = false,
      bool modificationId = false,
      bool chainModificationId = false,
      bool usedByOtherBuilds = false,
      // Group fields
      LinksField links = null,
      BuildTypeField buildType = null,
      CommentField comment = null,     
      TagsField tags = null,
      CommentField pinInfo = null,
      UserField user = null,
      ProgressInfoField running_info = null,
      CommentField canceledInfo = null,
      TriggeredField triggered = null,
      LastChangesField lastChanges = null,
      ChangesField changes = null,
      RevisionsField revisions = null,
      RevisionField versionedSettingsRevision = null,
      BuildChangesField artifactDependencyChanges = null,
      AgentField agent = null,
      CompatibleAgentsField compatibleAgents = null,
      TestOccurrencesField testOccurrences = null,
      ProblemOccurrencesField problemOccurrences = null,
      ArtifactsField artifacts = null,
      PropertiesField properties = null,
      PropertiesField resultingProperties = null,
      EntriesField attributes =null,
      StatisticsField statistics = null,
      DatasField metadata = null,
      BuildSnapshotDependenciesField snapshotDependencies = null,
      BuildArtifactDependenciesField artifactDependencies = null,
      ArtifactDependenciesField customArtifactDependencies = null,
      ItemsField replacementIds = null,
      RelatedField related =null,
      CommentField statusChangeComment = null,    
      RelatedIssuesField relatedIssues = null
      
      )
    {
      return new BuildField
      {
        // Fields
        Id = id,
        TaskId = taskId,
        BuildTypeId = buildTypeId,
        BuildTypeInternalId = buildTypeInternalId,
        Number = number,
        Status = status,
        State = state,
        Running = running,
        Composite = composite,
        FailedToStart = failedToStart,
        Personal = personal,
        PercentageComplete = percentageComplete,
        BranchName = branchName,
        DefaultBranch = defaultBranch,
        UnspecifiedBranch = unspecifiedBranch,
        History = history,
        Pinned = pinned,
        Href = href,
        WebUrl = webUrl,
        QueuePosition = queuePosition,
        LimitedChangesCount = limitedChangesCount,
        ArtifactsDirectory = artifactsDirectory,
        StatusText = statusText,
        StartEstimate =startEstimate,
        WaitReason = waitReason,
        StartDate = startDate,
        FinishDate = finishDate,
        QueuedDate = queuedDate,
        SettingsHash = settingsHash,
        CurrentSettingsHash = currentSettingsHash,
        ModificationId = modificationId,
        ChainModificationId = chainModificationId,
        UsedByOtherBuilds = usedByOtherBuilds,
        // GroupFields
        Links = links,
        BuildType = buildType,
        Comment = comment,
        Tags = tags,
        PinInfo = pinInfo,
        User = user,
        Running_info = running_info,
        CanceledInfo = canceledInfo,
        Triggered = triggered,
        LastChanges = lastChanges,
        Changes = changes,
        Revisions = revisions,
        VersionedSettingsRevision = versionedSettingsRevision,
        ArtifactDependencyChanges = artifactDependencyChanges,
        Agent = agent,
        CompatibleAgents = compatibleAgents,
        TestOccurrences = testOccurrences,
        ProblemOccurrences = problemOccurrences,
        Artifacts = artifacts,
        Properties = properties,
        ResultingProperties = resultingProperties,
        Attributes = attributes,
        Statistics = statistics,
        Metadata = metadata,
        SnapshotDependencies = snapshotDependencies,
        ArtifactDependencies = artifactDependencies,
        CustomArtifactDependencies = customArtifactDependencies,
        ReplacementIds = replacementIds,
        Related = related,
        StatusChangeComment =statusChangeComment,
        RelatedIssues = relatedIssues
        
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

      // Fields
      FieldHelper.AddField(Id, ref currentFields, "id");

      FieldHelper.AddField(TaskId, ref currentFields, "taskId");

      FieldHelper.AddField(BuildTypeId, ref currentFields, "buildTypeId");

      FieldHelper.AddField(BuildTypeInternalId, ref currentFields, "buildTypeInternalId");

      FieldHelper.AddField(Number, ref currentFields, "number");

      FieldHelper.AddField(Status, ref currentFields, "status");

      FieldHelper.AddField(State, ref currentFields, "state");

      FieldHelper.AddField(Running, ref currentFields,"running");

      FieldHelper.AddField(Composite, ref currentFields, "composite");

      FieldHelper.AddField(FailedToStart, ref currentFields, "failedToStart");

      FieldHelper.AddField(Personal, ref currentFields, "personal");

      FieldHelper.AddField(PercentageComplete, ref currentFields, "percentageComplete");

      FieldHelper.AddField(BranchName, ref currentFields, "branchName");
      
      FieldHelper.AddField(DefaultBranch, ref currentFields, "defaultBranch");

      FieldHelper.AddField(UnspecifiedBranch, ref currentFields, "unspecifiedBranch");

      FieldHelper.AddField(History, ref currentFields, "history");

      FieldHelper.AddField(Pinned, ref currentFields, "pinned");

      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddField(WebUrl, ref currentFields, "webUrl");

      FieldHelper.AddField(QueuePosition, ref currentFields, "queuePosition");

      FieldHelper.AddField(LimitedChangesCount, ref currentFields, "limitedChangesCount");

      FieldHelper.AddField(ArtifactsDirectory, ref currentFields, "artifactsDirectory");

      FieldHelper.AddField(StatusText, ref currentFields, "statusText");

      FieldHelper.AddField(StartEstimate, ref currentFields, "startEstimate");

      FieldHelper.AddField(WaitReason, ref currentFields, "waitReason");

      FieldHelper.AddField(StartDate, ref currentFields, "startDate");

      FieldHelper.AddField(FinishDate, ref currentFields, "finishDate");

      FieldHelper.AddField(QueuedDate, ref currentFields, "queuedDate");

      FieldHelper.AddField(SettingsHash, ref currentFields, "settingsHash");

      FieldHelper.AddField(CurrentSettingsHash, ref currentFields, "currentSettingsHash");
      
      FieldHelper.AddField(ModificationId, ref currentFields, "modificationId");

      FieldHelper.AddField(ChainModificationId, ref currentFields, "chainModificationId");

      FieldHelper.AddField(UsedByOtherBuilds, ref currentFields, "usedByOtherBuilds");

      // Group Fields

      FieldHelper.AddFieldGroup(Links, ref currentFields);

      FieldHelper.AddFieldGroup(BuildType, ref currentFields);

      FieldHelper.AddFieldGroup(Comment, ref currentFields);

      FieldHelper.AddFieldGroup(Tags, ref currentFields);

      FieldHelper.AddFieldGroup(PinInfo, ref currentFields, "pinInfo");

      FieldHelper.AddFieldGroup(User, ref currentFields);

      FieldHelper.AddFieldGroup(Running_info, ref currentFields, "running-info");

      FieldHelper.AddFieldGroup(CanceledInfo,ref currentFields, "canceledInfo");

      FieldHelper.AddFieldGroup(Triggered, ref currentFields);

      FieldHelper.AddFieldGroup(LastChanges, ref currentFields);

      FieldHelper.AddFieldGroup(Changes, ref currentFields);

      FieldHelper.AddFieldGroup(Revisions, ref currentFields);

      FieldHelper.AddFieldGroup(VersionedSettingsRevision, ref currentFields, "versionedSettingsRevision");

      FieldHelper.AddFieldGroup(ArtifactDependencyChanges, ref currentFields, "artifactDependencyChanges");

      FieldHelper.AddFieldGroup(Agent, ref currentFields);

      FieldHelper.AddFieldGroup(CompatibleAgents, ref currentFields, "compatibleAgents");

      FieldHelper.AddFieldGroup(TestOccurrences, ref currentFields);

      FieldHelper.AddFieldGroup(ProblemOccurrences, ref currentFields);

      FieldHelper.AddFieldGroup(Artifacts, ref currentFields);

      FieldHelper.AddFieldGroup(RelatedIssues, ref currentFields);

      FieldHelper.AddFieldGroup(Properties, ref currentFields);

      FieldHelper.AddFieldGroup(ResultingProperties, ref currentFields, "resultingProperties");

      FieldHelper.AddFieldGroup(Attributes, ref currentFields, "attributes");

      FieldHelper.AddFieldGroup(Statistics, ref currentFields);

      FieldHelper.AddFieldGroup(Metadata, ref currentFields, "metadata");

      FieldHelper.AddFieldGroup(SnapshotDependencies, ref currentFields);

      FieldHelper.AddFieldGroup(ArtifactDependencies, ref currentFields);

      FieldHelper.AddFieldGroup(CustomArtifactDependencies, ref currentFields, "custom-artifact-dependencies");

      FieldHelper.AddFieldGroup(ReplacementIds, ref currentFields, "replacementIds");

      FieldHelper.AddFieldGroup(Related, ref currentFields);

      FieldHelper.AddFieldGroup(StatusChangeComment, ref currentFields, "statusChangeComment");


     

      return currentFields;
    }

    #endregion
  }
}
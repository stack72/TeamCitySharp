using System;

namespace TeamCitySharp.Fields
{
  public class TestOccurrenceField : IField
  {
    #region Properties

    // Fields
    public bool Id { get; private set; }
    public bool Name { get; private set; }
    public bool Status { get; private set; }
    public bool Ignored { get; private set; }
    public bool Duration { get; private set; }
    public bool RunOrder { get; private set; }
    public bool Muted { get; private set; }
    public bool CurrentlyMuted { get; private set; }
    public bool CurrentlyInvestigated { get; private set; }
    public bool Href { get; private set; }
    public bool IgnoreDetails { get; private set; }
    public bool Details { get; private set; }
    public bool LogAnchor { get; private set; }

    // Group Fields
    public TestField Test { get; private set; }
    public MuteField Mute { get; private set; }
    public BuildField Build { get; private set; }
    public BuildField FirstFailed { get; private set; }
    public BuildField NextFixed { get; private set; }
    public TestOccurrencesField Invocations { get; private set; }
    public TestRunMetadataField Metadata { get; private set; }
    

    #endregion

    #region Public Methods

    public static TestOccurrenceField WithFields(
      // Fields
      bool id = false, 
      bool name = false,
      bool status = false,
      bool ignored= false,
      bool duration = false,
      bool runOrder = false,
      bool muted = false,
      bool currentlyMuted = false,
      bool currentlyInvestigated = false,
      bool href = false,
      bool ignoreDetails = false,
      bool details = false,
      bool logAnchor = false,
      // Group Fields
      TestField test = null,
      MuteField mute = null,
      BuildField build = null,
      BuildField firstFailed = null,
      BuildField nextFixed = null,
      TestOccurrencesField invocations = null,
      TestRunMetadataField metadata = null
      )
    {
      return new TestOccurrenceField
      {
        // Fields
        Id = id,
        Name = name,
        Status = status,
        Ignored= ignored,
        Duration = duration,
        RunOrder = runOrder,
        Muted = muted,
        CurrentlyMuted = currentlyMuted,
        CurrentlyInvestigated = currentlyInvestigated,
        Href = href,
        IgnoreDetails = ignoreDetails,
        Details = details,
        LogAnchor = logAnchor,
        // Group Fields
        Test = test,
        Mute = mute,
        Build = build,
        FirstFailed = firstFailed,
        NextFixed = nextFixed,
        Invocations = invocations,
        Metadata = metadata
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "testOccurrence"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Name, ref currentFields, "name");
      FieldHelper.AddField(Status, ref currentFields, "status");
      FieldHelper.AddField(Ignored, ref currentFields, "ignored");
      FieldHelper.AddField(Duration, ref currentFields, "duration");
      FieldHelper.AddField(RunOrder, ref currentFields, "runOrder");
      FieldHelper.AddField(Muted, ref currentFields, "muted");
      FieldHelper.AddField(CurrentlyMuted, ref currentFields, "currentlyMuted");
      FieldHelper.AddField(CurrentlyInvestigated, ref currentFields, "currentlyInvestigated");
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(IgnoreDetails, ref currentFields, "ignoreDetails");
      FieldHelper.AddField(Details, ref currentFields, "details");
      FieldHelper.AddField(LogAnchor, ref currentFields, "logAnchor");

      FieldHelper.AddFieldGroup(Test,ref currentFields);
      FieldHelper.AddFieldGroup(Mute, ref currentFields);
      FieldHelper.AddFieldGroup(Build, ref currentFields);
      FieldHelper.AddFieldGroup(FirstFailed, ref currentFields, "firstFailed");
      FieldHelper.AddFieldGroup(NextFixed, ref currentFields, "nextFixed");
      FieldHelper.AddFieldGroup(Invocations, ref currentFields, "invocations");
      FieldHelper.AddFieldGroup(Metadata, ref currentFields, "metadata");

      return currentFields;
    }

    #endregion
  }
}
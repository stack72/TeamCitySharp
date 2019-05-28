using System;

namespace TeamCitySharp.Fields
{
  public class ProblemOccurrenceField : IField
  {
    #region Properties

    // Fields
    public bool Id { get; private set; }
    public bool Type { get; private set; }
    public bool Identity { get; private set; }
    public bool Href { get; private set; }
    public bool Muted { get; private set; }
    public bool CurrentlyInvestigated { get; private set; }
    public bool CurrentlyMuted { get; private set; }
    public bool Details { get; private set; }
    public bool AdditionalData { get; private set; }
    public bool LogAnchor { get; private set; }

    // Group Fields
    public ProblemField Problem { get; private set; }
    public MuteField Mute { get; private set; }
    public BuildField Build { get; private set; }
    
    #endregion

    #region Public Methods

    public static ProblemOccurrenceField WithFields(
      // Fields
      bool id = false, 
      bool type = false,
      bool identity = false,
      bool href = false,
      bool muted = false,
      bool currentlyInvestigated = false,
      bool currentlyMuted = false,
      bool details = false,
      bool additionalData = false,
      bool logAnchor = false,
      // Group Fields
      ProblemField problem = null,
      MuteField mute = null,
      BuildField build = null
      )
    {
      return new ProblemOccurrenceField
      {
        // Fields
        Id = id,
        Type = type,
        Identity = identity,
        Href = href,
        Muted = muted,
        CurrentlyInvestigated = currentlyInvestigated,
        CurrentlyMuted = currentlyMuted,
        Details = details,
        AdditionalData = additionalData,
        LogAnchor = logAnchor,
        // Group Fields
        Problem = problem,
        Mute = mute,
        Build = build
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "problemOccurrence"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Type, ref currentFields, "type");
      FieldHelper.AddField(Identity, ref currentFields, "identity");
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(Muted, ref currentFields, "muted");
      FieldHelper.AddField(CurrentlyInvestigated, ref currentFields, "currentlyInvestigated");
      FieldHelper.AddField(CurrentlyMuted, ref currentFields, "currentlyMuted");
      FieldHelper.AddField(LogAnchor, ref currentFields, "logAnchor");
      FieldHelper.AddField(Details, ref currentFields, "details");
      FieldHelper.AddField(AdditionalData, ref currentFields, "additionalData");
      

      FieldHelper.AddFieldGroup(Problem,ref currentFields);
      FieldHelper.AddFieldGroup(Mute, ref currentFields);
      FieldHelper.AddFieldGroup(Build, ref currentFields);


      return currentFields;
    }

    #endregion
  }
}
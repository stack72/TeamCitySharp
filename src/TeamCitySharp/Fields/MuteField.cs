using System;

namespace TeamCitySharp.Fields
{
  public class MuteField : IField
  {
    #region Properties
    // Fields
    public bool Id { get; private set; }
    public bool Href { get; private set; }
    // Group fields
    public CommentField Assignment { get; private set; }
    public ProblemScopeField Scope { get; private set; }
    public ProblemTargetField Target { get; private set; }
    public ResolutionField Resolution { get; private set; }
    #endregion

    #region Public Methods

    public static MuteField WithFields(
      // Fields
      bool id = false,
      bool href = false,
      // Group Fields
      CommentField assignment = null,
      ProblemScopeField scope = null,
      ProblemTargetField target = null,
      ResolutionField resolution = null
      )
    {
      return new MuteField
      {
        // Fields
        Id = id,
        Href = href,
        // Group Fields
        Assignment = assignment,
        Scope = scope,
        Target = target,
        Resolution = resolution
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "mute"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddFieldGroup(Assignment, ref currentFields, "assignment");
      FieldHelper.AddFieldGroup(Scope, ref currentFields );
      FieldHelper.AddFieldGroup(Target, ref currentFields);
      FieldHelper.AddFieldGroup(Resolution, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
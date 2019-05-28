using System;

namespace TeamCitySharp.Fields
{
  public class ProblemField : IField
  {
    #region Properties

    // Fields
    public bool Id { get; private set; }
    public bool Type { get; private set; }
    public bool Identity { get; private set; }
    public bool Href { get; private set; }
    // Group Fields
    public MutesField Mutes { get; private set; }
    public InvestigationsField Investigations { get; private set; }
    public ProblemOccurrencesField ProblemOccurrences { get; private set; }
    

    #endregion

    #region Public Methods

    public static ProblemField WithFields(
      // Fields
      bool id = false, 
      bool type = false,
      bool identity = false,
      bool href = false,
      // Group Fields
      MutesField mutes = null,
      InvestigationsField investigations = null,
      ProblemOccurrencesField problemOccurrences = null
      )
    {
      return new ProblemField
      {
        // Fields
        Id = id,
        Type = type,
        Identity = identity,
        Href = href,
        // Group Fields
        Mutes = mutes,
        Investigations = investigations,
        ProblemOccurrences = problemOccurrences
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "problem"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Type, ref currentFields, "type");
      FieldHelper.AddField(Identity, ref currentFields, "identity");
      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddFieldGroup(Mutes, ref currentFields);
      FieldHelper.AddFieldGroup(Investigations, ref currentFields);
      FieldHelper.AddFieldGroup(ProblemOccurrences, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
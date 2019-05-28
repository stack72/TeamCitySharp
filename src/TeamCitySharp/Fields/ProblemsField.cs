using System;

namespace TeamCitySharp.Fields
{
  public class ProblemsField : IField
  {
    #region Properties
    // Fields
    public bool Count { get; private set; }
    public bool NextHref { get; private set; }
    public bool PrevHref { get; private set; }
    public bool Default { get; private set; }
    // Group Fields
    public ProblemField Problem { get; private set; }



    #endregion

    #region Public Methods

    public static ProblemsField WithFields(
      // Fields
      bool count = true, 
      bool nextHref = false, 
      bool prevHref = false,
      bool defaultValue = false,
      // Group Fields 
      ProblemField problem = null)
    {
      return new ProblemsField
      {
        // Fields
        Count = count,
        NextHref = nextHref,
        PrevHref = prevHref,
        Default = defaultValue,
        // Group Fields
        Problem = problem
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "problems"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      // Fields 
      FieldHelper.AddField(Count, ref currentFields, "count");
      FieldHelper.AddField(NextHref, ref currentFields, "nextHref");
      FieldHelper.AddField(PrevHref, ref currentFields, "prevHref");
      FieldHelper.AddField(Default, ref currentFields, "default");
      // Group Fields
      FieldHelper.AddFieldGroup(Problem, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

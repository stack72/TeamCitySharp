using System;

namespace TeamCitySharp.Fields
{
  public class ProblemTargetField : IField
  {
    #region Properties
    public bool AnyProblem { get; private set; }
    public TestsField Tests { get; private set; }
    public ProblemsField Problems { get; private set; }

    #endregion

    #region Public Methods

    public static ProblemTargetField WithFields(
      bool anyProblem = false,
      TestsField tests = null,
      ProblemsField problems = null)
    {
      return new ProblemTargetField
      {
        AnyProblem =  anyProblem,
        Tests = tests,
        Problems = problems
      };
    }

    #endregion
    #region Overrides IField

    public string FieldId
    {
      get { return "ProblemTarget"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;
      FieldHelper.AddField(AnyProblem, ref currentFields,"anyProblem");
      FieldHelper.AddFieldGroup(Tests, ref currentFields);
      FieldHelper.AddFieldGroup(Problems, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

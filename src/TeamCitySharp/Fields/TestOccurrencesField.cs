using System;

namespace TeamCitySharp.Fields
{
  public class TestOccurrencesField : IField
  {
    #region Properties

    public bool Count { get; private set; }
    public bool NextHref { get; private set; }
    public bool PrevHref { get; private set; }
    public bool Href { get; private set; }
    public TestOccurrenceField TestOccurrence { get; private set; }
    public bool Default { get; private set; }
    public bool Passed { get; private set; }
    public bool Failed { get; private set; }
    public bool NewFailed { get; private set; }
    public bool Ignored { get; private set; }
    public bool Muted { get; private set; }


    #endregion

    #region Public Methods

    public static TestOccurrencesField WithFields(
      bool count = true, 
      bool nextHref = false, 
      bool prevHref = false, 
      bool href = false, 
      bool defaultValue = false,
      bool passed = false,
      bool failed = false,
      bool newFailed = false,
      bool ignored = false,
      bool muted = false,
      TestOccurrenceField testOccurrence = null)
    {
      return new TestOccurrencesField
      {
        Count = count,
        NextHref = nextHref,
        PrevHref = prevHref,
        Href = href,
        Default = defaultValue,
        Passed = passed,
        Failed = failed,
        NewFailed = newFailed,
        Ignored = ignored,
        Muted = muted,
        TestOccurrence =  testOccurrence
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "testOccurrences"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddField(NextHref, ref currentFields, "nextHref");

      FieldHelper.AddField(PrevHref, ref currentFields, "prevHref");
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(Default, ref currentFields, "default");

      FieldHelper.AddField(Failed, ref currentFields, "failed");
      FieldHelper.AddField(NewFailed, ref currentFields, "newFailed");
      FieldHelper.AddField(Ignored, ref currentFields, "ignored");
      FieldHelper.AddField(Muted, ref currentFields, "muted");



      FieldHelper.AddFieldGroup(TestOccurrence, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

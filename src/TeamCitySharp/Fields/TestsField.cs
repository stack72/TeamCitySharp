using System;

namespace TeamCitySharp.Fields
{
  public class TestsField : IField
  {
    #region Properties

    // Fields
    public bool Count { get; private set; }
    public bool NextHref { get; private set; }
    public bool PrevHref { get; private set; }
    public bool Href { get; private set; }
    public bool Default { get; private set; }
    // Group Fields
    public TestField Test { get; private set; }
    
    #endregion

    #region Public Methods

    public static TestsField WithFields(
      // Fields
      bool count = true, 
      bool nextHref = false, 
      bool prevHref = false, 
      bool href = false, 
      bool defaultValue = false,
      // Group Field
      TestField test = null)
    {
      return new TestsField
      {
        //Fields
        Count = count,
        NextHref = nextHref,
        PrevHref = prevHref,
        Href = href,
        Default = defaultValue,
        //Group Fields
        Test =  test
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "tests"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      // Fields
      FieldHelper.AddField(Count, ref currentFields, "count");
      FieldHelper.AddField(NextHref, ref currentFields, "nextHref");
      FieldHelper.AddField(PrevHref, ref currentFields, "prevHref");
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(Default, ref currentFields, "default");

      // Group Fields
      FieldHelper.AddFieldGroup(Test, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

using System;

namespace TeamCitySharp.Fields
{
  public class TestField : IField
  {
    #region Properties

    // Fields
    public bool Id { get; private set; }
    public bool Name { get; private set; }
    public bool Href { get; private set; }

    // Group Fields
    public MutesField Mutes { get; private set; }
    public InvestigationsField Investigations { get; private set; }
    public TestOccurrencesField TestOccurrences { get; private set; }
    #endregion

    #region Public Methods

    public static TestField WithFields(
      // Fields
      bool id = false,
      bool name = false,
      bool href = false,
      // Group fields
      MutesField mutes = null,
      InvestigationsField investigations = null,
      TestOccurrencesField testOccurrences = null
    )
    {
      return new TestField
      {
        // Fields
        Id = id,
        Name = name,
        Href = href,

        // Group Fields
        Mutes = mutes,
        Investigations = investigations,
        TestOccurrences = testOccurrences
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "test"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Name, ref currentFields, "name");
      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddFieldGroup(Mutes, ref currentFields);
      FieldHelper.AddFieldGroup(Investigations, ref currentFields);
      FieldHelper.AddFieldGroup(TestOccurrences, ref currentFields);


      return currentFields;
    }

    #endregion
  }
}
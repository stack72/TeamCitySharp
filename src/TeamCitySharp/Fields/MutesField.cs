using System;

namespace TeamCitySharp.Fields
{
  public class MutesField : IField
  {
    #region Properties
    // Fields
    public bool Count { get; private set; }
    public bool NextHref { get; private set; }
    public bool PrevHref { get; private set; }
    public bool Default { get; private set; }
    public bool Href { get; private set; }
    // Group Fields
    public MuteField Mute { get; private set; }



    #endregion

    #region Public Methods

    public static MutesField WithFields(
      // Fields
      bool count = true, 
      bool nextHref = false, 
      bool prevHref = false,
      bool defaultValue = false,
      bool href = false, 
      // Group Fields 
      MuteField mute = null)
    {
      return new MutesField
      {
        // Fields
        Count = count,
        NextHref = nextHref,
        PrevHref = prevHref,
        Default = defaultValue,
        Href = href,
       // Group Fields
        Mute = mute
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "mutes"; }
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
      FieldHelper.AddFieldGroup(Mute, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

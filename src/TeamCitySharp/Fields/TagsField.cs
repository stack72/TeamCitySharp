using System;

namespace TeamCitySharp.Fields
{
  public class TagsField : IField
  {
    #region Properties

    public TagField Tag { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static TagsField WithFields(TagField tag = null,
                                       bool count = true)
    {
      return new TagsField
        {
          Tag = tag,
          Count = count,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "tags"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");

      FieldHelper.AddFieldGroup(Tag, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

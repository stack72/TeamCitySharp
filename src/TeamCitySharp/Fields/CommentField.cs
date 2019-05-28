using System;

namespace TeamCitySharp.Fields
{
  public class CommentField : IField
  {
    #region Properties


    public bool Timestamp { get; private set; }
    public bool Text { get; private set; }
    public UserField User { get; private set; }

    #endregion

    #region Public Methods

    public static CommentField WithFields(bool timestamp = false, bool text = false, UserField user = null)
    {
      return new CommentField
      {
        Timestamp = timestamp,
        Text = text,
        User = user,
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "comment"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Timestamp, ref currentFields, "count");
      FieldHelper.AddField(Text, ref currentFields, "href");

      FieldHelper.AddFieldGroup(User, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
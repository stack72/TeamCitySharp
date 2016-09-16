using System;

namespace TeamCitySharp.Fields
{
  public class TagField : IField
  {
    #region Properties

    public bool Name { get; private set; }
    
    #endregion

    #region Public Methods

    public static TagField WithFields(bool name = false)
    {
      return new TagField
        {
          Name = name
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "tag"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Name, ref currentFields, "name");

      return currentFields;
    }

    #endregion
  }
}
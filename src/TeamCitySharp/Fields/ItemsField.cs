using System;

namespace TeamCitySharp.Fields
{
  public class ItemsField : IField
  {
    #region Properties

    public bool Item { get; private set; }
    
    #endregion

    #region Public Methods

    public static ItemsField WithFields(bool item = false)
    {
      return new ItemsField
      {
        Item = item
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "items"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Item, ref currentFields, "item");

      return currentFields;
    }

    #endregion
  }
}
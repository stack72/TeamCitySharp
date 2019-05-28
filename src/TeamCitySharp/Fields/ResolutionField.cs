using System;

namespace TeamCitySharp.Fields
{
  public class ResolutionField : IField
  {
    #region Properties

    public bool Type { get; private set; }
    public bool Time { get; private set; }

    #endregion

    #region Public Methods

    public static ResolutionField WithFields(bool type = false, bool time = false)
    {
      return new ResolutionField
      {
          Type = type,
          Time = time
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "resolution"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Type, ref currentFields, "type");
      FieldHelper.AddField(Time, ref currentFields, "time");

      return currentFields;
    }

    #endregion
  }
}
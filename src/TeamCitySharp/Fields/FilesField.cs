using System;

namespace TeamCitySharp.Fields
{
  public class FilesField : IField
  {
    #region Properties
    public FileField FileField { get; private set; }
    #endregion

    #region Public Methods

    public static FilesField WithFields(FileField fileField = null)
    {
      return new FilesField
      {
        FileField = fileField
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "files"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddFieldGroup(FileField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}



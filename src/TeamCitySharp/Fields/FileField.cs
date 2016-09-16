using System;

namespace TeamCitySharp.Fields
{
  public class FileField : IField
  {
    #region Properties
    public bool BeforeRevision { get; private set; }
    public bool AfterRevision { get; private set; }
    public bool File { get; private set; }
    public bool RelativeFile { get; private set; }
    #endregion
    
    #region Public Methods
    public static FileField WithFields(bool beforeRevision = false, bool afterRevision = false, bool file = false, bool relativeFile = false)
    {
      return new FileField
      {
       BeforeRevision = beforeRevision,
       AfterRevision = afterRevision,
       File = file,
       RelativeFile = relativeFile
      };
    }

    #endregion
    #region Overrides IField

    public string FieldId
    {
      get { return "file"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(BeforeRevision, ref currentFields, "before-revision");
      FieldHelper.AddField(AfterRevision, ref currentFields, "after-revision");
      FieldHelper.AddField(File, ref currentFields, "file");
      FieldHelper.AddField(RelativeFile, ref currentFields, "relative-file");

      return currentFields;
    }

    #endregion
  }
}

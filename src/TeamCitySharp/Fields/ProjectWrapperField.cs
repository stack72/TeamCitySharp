using System;

namespace TeamCitySharp.Fields
{
  public class ProjectWrapperField : IField
  {
    #region Properties

    public ProjectField Project { get; private set; }
    public bool Count { get; private set; }

    #endregion

    #region Public Methods

    public static ProjectWrapperField WithFields(ProjectField project = null,
                                                 bool count = true)
    {
      return new ProjectWrapperField
        {
          Project = project,
          Count = count
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "projects"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Count, ref currentFields, "count");
      FieldHelper.AddFieldGroup(Project, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}
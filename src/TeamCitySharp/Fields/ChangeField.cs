using System;

namespace TeamCitySharp.Fields
{
  public class ChangeField : IField
  {
    #region Properties
    public bool Id { get; private set; }
    public bool Version { get; private set; }
    public bool Username { get; private set; }
    public bool Href { get; private set; }
    public bool WebUrl { get; private set; }
    public bool WebLink { get; private set; }
    public bool Date { get; private set; }
    public bool Comment { get; private set; }
    public bool Personal { get; private set; }
    public UserField UserField { get; private set; }
    public FilesField FilesField { get; private set; }
    public VcsRootField VcsRootField { get; private set; }
    public VcsRootInstanceField VcsRootInstanceField { get; private set; }
    public ChangeVcsRootInstanceField ChangeVcsRootInstanceField { get; private set; }
    #endregion

    #region Public Methods
    public static ChangeField WithFields( bool id = false, 
                                          bool version = false, 
                                          bool username = false, 
                                          bool href = false,
                                          bool weburl = false,
                                          bool weblink = false,
                                          bool date = false,
                                          bool comment = false, 
                                          bool personal = false,
                                          UserField userField = null, 
                                          FilesField filesField = null,
                                          VcsRootField vcsRootField = null,
                                          VcsRootInstanceField vcsRootInstanceField=null,
                                          ChangeVcsRootInstanceField changeVcsRootInstanceField=null)
    {
      return new ChangeField
      {
        Id = id,
        Version = version,
        Username = username,
        Href = href,
        WebUrl = weburl,
        WebLink = weblink,
        Date = date,
        Comment = comment,
        Personal = personal,
        UserField = userField,
        FilesField = filesField,
        VcsRootField = vcsRootField,
        VcsRootInstanceField = vcsRootInstanceField,
        ChangeVcsRootInstanceField = changeVcsRootInstanceField
      };
    }

    #endregion
    #region Overrides IField

    public string FieldId
    {
      get { return "change"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Version, ref currentFields, "version");
      FieldHelper.AddField(Username, ref currentFields, "username");
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(WebUrl, ref currentFields, "webUrl");
      FieldHelper.AddField(WebLink, ref currentFields, "webLink");
      FieldHelper.AddField(Date, ref currentFields, "date");
      FieldHelper.AddField(Comment, ref currentFields, "comment");
      FieldHelper.AddField(Personal, ref currentFields, "personal");

      FieldHelper.AddFieldGroup(UserField, ref currentFields);
      FieldHelper.AddFieldGroup(FilesField, ref currentFields);
      FieldHelper.AddFieldGroup(VcsRootField, ref currentFields);
      FieldHelper.AddFieldGroup(VcsRootInstanceField, ref currentFields);
      FieldHelper.AddFieldGroup(ChangeVcsRootInstanceField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

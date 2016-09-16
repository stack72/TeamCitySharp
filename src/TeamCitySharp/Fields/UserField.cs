using System;

namespace TeamCitySharp.Fields
{
  public class UserField : IField
  {
    #region Properties
    public bool Username { get; private set; }
    public bool Name { get; private set; }
    public bool Id { get; private set; }
    public bool Email { get; private set; }
    public bool LastLogin { get; private set; }
    public bool Href { get; private set; }
    public PropertiesField PropertiesField { get; private set; }
    
    //TODO: Implement missing field
    /*  
    public RolesField RolesField { get; private set; }
    public GroupsField GroupsField { get; private set; }
    public FilesField FilesField { get; private set; }
    */
    #endregion

    #region Public Methods

    public static UserField WithFields( bool username = false, bool name = false, bool id = false, bool email = false, bool lastlogin = false, bool href = false, PropertiesField propertiesField = null)
    {
      return new UserField
      {
        Username = username,
        Name = name,
        Id = id,
        Email = email,
        LastLogin = lastlogin,
        Href = href,
        PropertiesField = propertiesField
      };
    }

    #endregion
    #region Overrides IField

    public string FieldId
    {
      get { return "user"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Username, ref currentFields, "username");
      FieldHelper.AddField(Name, ref currentFields, "name");
      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Email, ref currentFields, "email");
      FieldHelper.AddField(LastLogin, ref currentFields, "lastLogin");
      FieldHelper.AddField(Href, ref currentFields, "href");
      
      FieldHelper.AddFieldGroup(PropertiesField, ref currentFields);

      return currentFields;
    }

    #endregion
  }
}

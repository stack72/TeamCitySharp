using System;

namespace TeamCitySharp.Fields
{
  public class ParentProjectField : IField
  {
    #region Properties

    public bool Archived { get; private set; }
    public bool Description { get; private set; }
    public bool Href { get; private set; }
    public bool Id { get; private set; }
    public bool Name { get; private set; }
    public bool WebUrl { get; private set; }

    #endregion

    #region Public Methods

    public static ParentProjectField WithFields(bool archived = false,
                                                bool description = false,
                                                bool href = false,
                                                bool id = false,
                                                bool name = false,
                                                bool webUrl = false)
    {
      return new ParentProjectField
        {
          Archived = archived,
          Description = description,
          Href = href,
          Id = id,
          Name = name,
          WebUrl = webUrl
        };
    }

    #endregion

    #region Overwrides IField

    public string FieldId
    {
      get { return "parentProject"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Archived, ref currentFields, "archived");
      FieldHelper.AddField(Description, ref currentFields, "description");
      FieldHelper.AddField(Href, ref currentFields, "href");
      FieldHelper.AddField(Id, ref currentFields, "id");
      FieldHelper.AddField(Name, ref currentFields, "name");


      return currentFields;
    }

    #endregion
  }
}
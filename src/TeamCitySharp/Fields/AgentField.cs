using System;

namespace TeamCitySharp.Fields
{
  public class AgentField : IField
  {
    #region Properties

    public bool Id { get; private set; }
    public bool Name { get; private set; }
    public bool Href { get; private set; }

    #endregion

    #region Public Methods

    public static AgentField WithFields(bool id = false,
                                        bool name = false,
                                        bool href = false)
    {
      return new AgentField
        {
          Id = id,
          Name = name,
          Href = href,
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "agent"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");

      FieldHelper.AddField(Name, ref currentFields, "name");

      FieldHelper.AddField(Href, ref currentFields, "href");

      return currentFields;
    }

    #endregion
  }
}
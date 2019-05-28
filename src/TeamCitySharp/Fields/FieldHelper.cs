namespace TeamCitySharp.Fields
{
  internal class FieldHelper
  {
    public static void AddField(bool bTypeField, ref string currentFields, string fieldId)
    {
      if (bTypeField)
      {
        if (currentFields != string.Empty)
          currentFields = currentFields + "," + fieldId;
        else
          currentFields = fieldId;
      }
    }

    public static void AddFieldGroup(IField field, ref string currentFields, string fieldId="")
    {
      if (field != null)
      {
        var currentFieldId = fieldId == "" ? field.FieldId : fieldId;
        var fieldToStr = field.ToString();
        var commaStr = string.Empty;
        if (currentFields != string.Empty)
          commaStr = ",";

        if (fieldToStr != string.Empty)
          currentFields = currentFields + commaStr + currentFieldId + "(" + field.ToString() + ")";
        else
          currentFields = currentFields + commaStr + currentFieldId;
      }
    }
  }
}
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

    public static void AddFieldGroup(IField field, ref string currentFields)
    {
      if (field != null)
      {
        var fieldToStr = field.ToString();
        var commaStr = string.Empty;
        if (currentFields != string.Empty)
          commaStr = ",";

        if (fieldToStr != string.Empty)
          currentFields = currentFields + commaStr + field.FieldId + "(" + field.ToString() + ")";
        else
          currentFields = currentFields + commaStr + field.FieldId;
      }
    }
  }
}
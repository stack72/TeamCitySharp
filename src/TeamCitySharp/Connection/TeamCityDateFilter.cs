using System;
using System.Collections.Generic;
using System.Globalization;
using JsonFx.IO;
using JsonFx.Model;
using JsonFx.Model.Filters;
using JsonFx.Serialization;

namespace TeamCitySharp.Connection
{
  public class TeamCityDateFilter : ModelFilter<DateTime>
  {
    private const string DateFormat = "yyyyMMddTHHmmsszz00";

    public override bool TryRead(DataReaderSettings settings, IStream<Token<ModelTokenType>> tokens, out DateTime value)
    {
      var token = tokens.Peek();
      if (token == null || token.TokenType != ModelTokenType.Primitive || !(token.Value is string))
      {
        value = default(DateTime);
        return false;
      }

      if (!TryParseDate(token.ValueAsString(), out value))
      {
        value = default(DateTime);
        return false;
      }

      tokens.Pop();
      return true;
    }

    public override bool TryWrite(DataWriterSettings settings, DateTime value,
                                  out IEnumerable<Token<ModelTokenType>> tokens)
    {
      tokens = new[]
        {
          ModelGrammar.TokenPrimitive(FormatDate(value))
        };

      return true;
    }

    internal static bool TryParseDate(string date, out DateTime value)
    {
      return DateTime.TryParseExact(date, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
    }

    private static string FormatDate(DateTime value)
    {
      return value.ToString(DateFormat);
    }
  }
}
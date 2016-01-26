using System.Collections.Generic;
using System.IO;
using EasyHttp.Codecs;
using EasyHttp.Codecs.JsonFXExtensions;
using EasyHttp.Configuration;
using JsonFx.IO;
using JsonFx.Json;
using JsonFx.Model;
using JsonFx.Serialization;
using JsonFx.Serialization.Filters;

namespace TeamCitySharp.Connection
{
  public class TeamcityJsonEncoderDecoderConfiguration : IEncoderDecoderConfiguration
  {
    public IEncoder GetEncoder()
    {
      var jsonWriter =
        new CamelCaseJsonWriter(new DataWriterSettings(DefaultEncoderDecoderConfiguration.CombinedResolverStrategy()
                                                       , new TeamCityDateFilter()),
                                new[] {"application/.*json", "text/.*json"});

      var writers = new List<IDataWriter> {jsonWriter};
      var dataWriterProvider = new RegExBasedDataWriterProvider(new List<IDataWriter> {jsonWriter});
      return new DefaultEncoder(dataWriterProvider);
    }

    public IDecoder GetDecoder()
    {
      var jsonReader =
        new JsonReader(new DataReaderSettings(DefaultEncoderDecoderConfiguration.CombinedResolverStrategy()
                                              , new TeamCityDateFilter()), new[] {"application/.*json", "text/.*json"});

      var readers = new List<IDataReader> {jsonReader};
      var dataReaderProvider = new RegExBasedDataReaderProvider(readers);
      return new DefaultDecoder(dataReaderProvider);
    }
  }

  public class CamelCaseJsonWriter : JsonWriter
  {
    public CamelCaseJsonWriter(DataWriterSettings settings, params string[] contentTypes)
      : base(settings, contentTypes)
    {
    }

    protected override ITextFormatter<ModelTokenType> GetFormatter()
    {
      return new CamelCaseJsonFormatter(this.Settings);
    }
  }

  public class CamelCaseJsonFormatter : JsonWriter.JsonFormatter
  {
    public CamelCaseJsonFormatter(DataWriterSettings settings)
      : base(settings)
    {
    }

    protected override void WritePropertyName(TextWriter writer, string propertyName)
    {
      base.WritePropertyName(writer, CamelCase(propertyName));
    }

    private static string CamelCase(string input)
    {
      if (string.IsNullOrEmpty(input))
        return input;

      var chars = input.ToCharArray();
      chars[0] = chars[0].ToString().ToLower().ToCharArray()[0];

      return new string(chars);
    }
  }
}
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
            var jsonWriter = new LowerCaseJsonWriter(new DataWriterSettings(DefaultEncoderDecoderConfiguration.CombinedResolverStrategy()
                , new TeamCityDateFilter()), new[] { "application/.*json", "text/.*json" });

            var writers = new List<IDataWriter> { jsonWriter };
            var dataWriterProvider = new RegExBasedDataWriterProvider(new List<IDataWriter> { jsonWriter });
            return new DefaultEncoder(dataWriterProvider);
        }

        public IDecoder GetDecoder()
        {
            var jsonReader = new JsonReader(new DataReaderSettings(DefaultEncoderDecoderConfiguration.CombinedResolverStrategy()
                , new TeamCityDateFilter()), new[] { "application/.*json", "text/.*json" });

            var readers = new List<IDataReader> { jsonReader };
            var dataReaderProvider = new RegExBasedDataReaderProvider(readers);
            return new DefaultDecoder(dataReaderProvider);
        }
    }

    public class LowerCaseJsonWriter : JsonWriter
    {
        public LowerCaseJsonWriter(DataWriterSettings settings, params string[] contentTypes):base(settings, contentTypes)
        {}

        protected override ITextFormatter<ModelTokenType> GetFormatter()
        {
            return new LowerCaseJsonFormatter(this.Settings);
        }
    }

    public class LowerCaseJsonFormatter : JsonWriter.JsonFormatter
    {
        public LowerCaseJsonFormatter(DataWriterSettings settings) : base(settings)
        {}

        protected override void WritePropertyName(TextWriter writer, string propertyName)
        {
            base.WritePropertyName(writer, propertyName.ToLower());
        }
    }
}
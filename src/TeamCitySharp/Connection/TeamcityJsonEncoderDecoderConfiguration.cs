using System.Collections.Generic;
using EasyHttp.Codecs;
using EasyHttp.Codecs.JsonFXExtensions;
using EasyHttp.Configuration;
using JsonFx.Json;
using JsonFx.Serialization;

namespace TeamCitySharp.Connection
{
    public class TeamcityJsonEncoderDecoderConfiguration : IEncoderDecoderConfiguration
    {
        public IEncoder GetEncoder()
        {
            var jsonWriter = new JsonWriter(new DataWriterSettings(DefaultEncoderDecoderConfiguration.CombinedResolverStrategy()
                , new TeamCityDateFilter()), new[] { "application/.*json", "text/.*json" });

            var writers = new List<IDataWriter> { jsonWriter };
            var dataWriterProvider = new RegExBasedDataWriterProvider(new List<IDataWriter> { jsonWriter });
            return new DefaultEncoder(dataWriterProvider);
        }

        public IDecoder GetDecoder(bool shouldRemoveAtSign = true)
        {
            var jsonReader = new JsonReader(new DataReaderSettings(DefaultEncoderDecoderConfiguration.CombinedResolverStrategy()
                , new TeamCityDateFilter()), new[] { "application/.*json", "text/.*json" });

            var readers = new List<IDataReader> { jsonReader };
            var dataReaderProvider = new RegExBasedDataReaderProvider(readers);
            return new DefaultDecoder(dataReaderProvider);
        }
    }
}
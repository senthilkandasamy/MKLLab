using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Markel.Claims.Service.Data.JsonConverters
{
    public class MarkelBooleanConverter : JsonConverter<bool>
    {
        public override bool Read(
               ref Utf8JsonReader reader,
               Type typeToConvert,
               JsonSerializerOptions options) =>
               bool.Parse(reader.GetString()!);

        public override void Write(
            Utf8JsonWriter writer,
            bool b,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(b.ToString());
    }
    
}

using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace AmeisenNavigation.Tester
{
    internal sealed class Vector3Converter : JsonConverter<Vector3>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(Vector3);
        }

        [SkipLocalsInit]
        public override Vector3 Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            float x = 0;
            float y = 0;
            float z = 0;

            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                if (reader.TokenType != JsonTokenType.PropertyName)
                    continue;

                if (reader.ValueTextEquals("x"u8))
                {
                    reader.Read();
                    x = reader.GetSingle();
                }
                else if (reader.ValueTextEquals("y"u8))
                {
                    reader.Read();
                    y = reader.GetSingle();
                }
                else if (reader.ValueTextEquals("z"u8))
                {
                    reader.Read();
                    z = reader.GetSingle();
                }
            }

            return new Vector3(x, y, z);
        }

        public override void Write(Utf8JsonWriter writer,
            Vector3 value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("x"u8, value.X);
            writer.WriteNumber("y"u8, value.Y);
            writer.WriteNumber("z"u8, value.Z);
            writer.WriteEndObject();
        }
    }

}

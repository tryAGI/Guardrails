#nullable enable

namespace Guardrails.JsonConverters
{
    /// <inheritdoc />
    public sealed class FailResultOutcomeNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Guardrails.FailResultOutcome?>
    {
        /// <inheritdoc />
        public override global::Guardrails.FailResultOutcome? Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case global::System.Text.Json.JsonTokenType.String:
                {
                    var stringValue = reader.GetString();
                    if (stringValue != null)
                    {
                        return global::Guardrails.FailResultOutcomeExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Guardrails.FailResultOutcome)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Guardrails.FailResultOutcome?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Guardrails.FailResultOutcome? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Guardrails.FailResultOutcomeExtensions.ToValueString(value.Value));
            }
        }
    }
}

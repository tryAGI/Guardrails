#nullable enable

namespace Guardrails.JsonConverters
{
    /// <inheritdoc />
    public sealed class ValidationResultOutcomeNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Guardrails.ValidationResultOutcome?>
    {
        /// <inheritdoc />
        public override global::Guardrails.ValidationResultOutcome? Read(
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
                        return global::Guardrails.ValidationResultOutcomeExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Guardrails.ValidationResultOutcome)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Guardrails.ValidationResultOutcome?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Guardrails.ValidationResultOutcome? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Guardrails.ValidationResultOutcomeExtensions.ToValueString(value.Value));
            }
        }
    }
}

#nullable enable

namespace Guardrails.JsonConverters
{
    /// <inheritdoc />
    public sealed class ValidatorReferenceOnFailJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Guardrails.ValidatorReferenceOnFail>
    {
        /// <inheritdoc />
        public override global::Guardrails.ValidatorReferenceOnFail Read(
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
                        return global::Guardrails.ValidatorReferenceOnFailExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Guardrails.ValidatorReferenceOnFail)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Guardrails.ValidatorReferenceOnFail);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Guardrails.ValidatorReferenceOnFail value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::Guardrails.ValidatorReferenceOnFailExtensions.ToValueString(value));
        }
    }
}

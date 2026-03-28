
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Guardrails
{
    /// <summary>
    /// 
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
            typeof(global::Guardrails.JsonConverters.ValidatorReferenceOnFailJsonConverter),

            typeof(global::Guardrails.JsonConverters.ValidatorReferenceOnFailNullableJsonConverter),

            typeof(global::Guardrails.JsonConverters.ValidatePayloadLlmApiJsonConverter),

            typeof(global::Guardrails.JsonConverters.ValidatePayloadLlmApiNullableJsonConverter),

            typeof(global::Guardrails.JsonConverters.ValidationSummaryValidatorStatusJsonConverter),

            typeof(global::Guardrails.JsonConverters.ValidationSummaryValidatorStatusNullableJsonConverter),

            typeof(global::Guardrails.JsonConverters.FailResultOutcomeJsonConverter),

            typeof(global::Guardrails.JsonConverters.FailResultOutcomeNullableJsonConverter),

            typeof(global::Guardrails.JsonConverters.ValidationResultOutcomeJsonConverter),

            typeof(global::Guardrails.JsonConverters.ValidationResultOutcomeNullableJsonConverter),

            typeof(global::Guardrails.JsonConverters.UnixTimestampJsonConverter),
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.HealthCheck))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.HttpError))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IList<string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.Guard))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.ValidatorReference>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidatorReference))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.Call>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.Call))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidatorReferenceOnFail), TypeInfoPropertyName = "ValidatorReferenceOnFail2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<object>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidatePayload))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidatePayloadLlmApi), TypeInfoPropertyName = "ValidatePayloadLlmApi2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidationOutcome))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.ValidationSummary>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidationSummary))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.Reask))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidationSummaryValidatorStatus), TypeInfoPropertyName = "ValidationSummaryValidatorStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.ErrorSpan>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ErrorSpan))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.FailResult>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.FailResult))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.FailResultOutcome), TypeInfoPropertyName = "FailResultOutcome2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.Iteration>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.Iteration))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.CallInputs))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.Inputs))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.Outputs))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.LLMResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.Reask>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.ValidatorLog>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidatorLog))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidationResult))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTime))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.ValidationResultOutcome), TypeInfoPropertyName = "ValidationResultOutcome2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.OpenAIChatCompletionPayload))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.OpenAIChatMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.OpenAIChatMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.OpenAIChatCompletion))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.OpenAIChatCompletionChoice>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Guardrails.OpenAIChatCompletionChoice))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Guardrails.Guard>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.List<string>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.ValidatorReference>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.Call>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<object>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.ValidationSummary>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.ErrorSpan>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.FailResult>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.Iteration>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.Reask>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.ValidatorLog>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.OpenAIChatMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.OpenAIChatCompletionChoice>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Guardrails.Guard>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}
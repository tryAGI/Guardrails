#nullable enable

namespace Guardrails
{
    public partial interface IValidateClient
    {
        /// <summary>
        /// Runs the validations specified in a Guard
        /// </summary>
        /// <param name="guardName"></param>
        /// <param name="xOpenaiApiKey"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Guardrails.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Guardrails.ValidationOutcome> ValidateAsync(
            string guardName,

            global::Guardrails.ValidatePayload request,
            string? xOpenaiApiKey = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Runs the validations specified in a Guard
        /// </summary>
        /// <param name="guardName"></param>
        /// <param name="xOpenaiApiKey"></param>
        /// <param name="llmOutput">
        /// The LLM output as a string or the input prompts for the LLM<br/>
        /// Example: stubbed llm output
        /// </param>
        /// <param name="numReasks">
        /// An override for the number of re-asks to perform
        /// </param>
        /// <param name="promptParams">
        /// Additional params for llm prompts
        /// </param>
        /// <param name="llmApi">
        /// The LLM API to use for validation
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Guardrails.ValidationOutcome> ValidateAsync(
            string guardName,
            string? xOpenaiApiKey = default,
            string? llmOutput = default,
            int? numReasks = default,
            object? promptParams = default,
            global::Guardrails.ValidatePayloadLlmApi? llmApi = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}
#nullable enable

namespace Guardrails
{
    public partial interface IGuardClient
    {
        /// <summary>
        /// Updates a Guard
        /// </summary>
        /// <param name="guardName"></param>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Guardrails.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Guardrails.Guard> UpdateGuardAsync(
            string guardName,

            global::Guardrails.Guard request,
            global::Guardrails.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Updates a Guard
        /// </summary>
        /// <param name="guardName"></param>
        /// <param name="id">
        /// The unique identifier for the Guard.
        /// </param>
        /// <param name="name">
        /// The name for the Guard.
        /// </param>
        /// <param name="description">
        /// A description that concisely states the expected behaviour or purpose of the Guard.
        /// </param>
        /// <param name="validators"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Guardrails.Guard> UpdateGuardAsync(
            string guardName,
            string id,
            string name,
            string? description = default,
            global::System.Collections.Generic.IList<global::Guardrails.ValidatorReference>? validators = default,
            global::Guardrails.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}
#nullable enable

namespace Guardrails
{
    public partial interface IServiceHealthClient
    {
        /// <summary>
        /// Returns the status of the server
        /// </summary>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Guardrails.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Guardrails.HealthCheck> HealthCheckAsync(
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}
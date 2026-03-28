#nullable enable

namespace Guardrails
{
    public partial interface IGuardClient
    {
        /// <summary>
        /// Fetches a specific Guard
        /// </summary>
        /// <param name="guardName"></param>
        /// <param name="asOf"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Guardrails.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Guardrails.Guard> GetGuardAsync(
            string guardName,
            global::System.DateTime? asOf = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}
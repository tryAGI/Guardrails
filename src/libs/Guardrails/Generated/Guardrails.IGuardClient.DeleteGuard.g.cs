#nullable enable

namespace Guardrails
{
    public partial interface IGuardClient
    {
        /// <summary>
        /// Deletes a Guard
        /// </summary>
        /// <param name="guardName"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Guardrails.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Guardrails.Guard> DeleteGuardAsync(
            string guardName,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}
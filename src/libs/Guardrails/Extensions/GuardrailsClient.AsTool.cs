#pragma warning disable CS3002 // Return type is not CLS-compliant
using System.Text.Json;
using Microsoft.Extensions.AI;

namespace Guardrails;

/// <summary>
/// Extensions for using GuardrailsClient as MEAI tools with any IChatClient.
/// </summary>
public static class GuardrailsToolExtensions
{
    /// <summary>
    /// Creates an <see cref="AIFunction"/> that validates LLM output against a named Guard.
    /// This is the primary tool for content validation, hallucination detection, PII protection, and toxicity checks.
    /// </summary>
    /// <param name="client">The Guardrails client to use for validation.</param>
    /// <param name="numReasks">Optional override for the number of re-asks to perform (default: no override).</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsValidateTool(
        this GuardrailsClient client,
        int? numReasks = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string guardName, string llmOutput, CancellationToken cancellationToken) =>
            {
                var response = await client.Validate.ValidateAsync(
                    guardName: guardName,
                    llmOutput: llmOutput,
                    numReasks: numReasks,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return FormatValidationOutcome(response);
            },
            name: "ValidateWithGuard",
            description: "Validates LLM output against a named Guardrails guard. Checks for issues like hallucination, PII, toxicity, and other content safety concerns. Returns whether validation passed and any failure details.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that lists all available Guards.
    /// </summary>
    /// <param name="client">The Guardrails client.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsListGuardsTool(this GuardrailsClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (CancellationToken cancellationToken) =>
            {
                var guards = await client.Guard.GetGuardsAsync(
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return FormatGuardList(guards);
            },
            name: "ListGuards",
            description: "Lists all available Guardrails guards the user has access to. Returns guard names, descriptions, and configured validators.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that fetches a specific Guard's configuration.
    /// </summary>
    /// <param name="client">The Guardrails client.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsGetGuardTool(this GuardrailsClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string guardName, CancellationToken cancellationToken) =>
            {
                var guard = await client.Guard.GetGuardAsync(
                    guardName: guardName,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return FormatGuard(guard);
            },
            name: "GetGuard",
            description: "Fetches the configuration for a specific Guardrails guard by name. Returns its validators, description, and settings.");
    }

    private static string FormatValidationOutcome(ValidationOutcome outcome)
    {
        var parts = new List<string>
        {
            $"Validation Passed: {outcome.ValidationPassed?.ToString() ?? "unknown"}",
            $"Call ID: {outcome.CallId}",
        };

        if (!string.IsNullOrWhiteSpace(outcome.RawLlmOutput))
        {
            parts.Add($"Raw LLM Output: {outcome.RawLlmOutput}");
        }

        if (!string.IsNullOrWhiteSpace(outcome.ValidatedOutput))
        {
            parts.Add($"Validated Output: {outcome.ValidatedOutput}");
        }

        if (!string.IsNullOrWhiteSpace(outcome.Error))
        {
            parts.Add($"Error: {outcome.Error}");
        }

        if (outcome.ValidationSummaries is { Count: > 0 })
        {
            parts.Add("Validation Summaries:");
            foreach (var summary in outcome.ValidationSummaries)
            {
                var entry = $"  - {summary.ValidatorName}: {summary.ValidatorStatus}";
                if (!string.IsNullOrWhiteSpace(summary.FailureReason))
                {
                    entry += $" ({summary.FailureReason})";
                }

                if (summary.ErrorSpans is { Count: > 0 })
                {
                    entry += $" [spans: {string.Join(", ", summary.ErrorSpans.Select(s => $"{s.Start}-{s.End}: {s.Reason}"))}]";
                }

                parts.Add(entry);
            }
        }

        return string.Join("\n", parts);
    }

    private static string FormatGuardList(IList<Guard> guards)
    {
        if (guards.Count == 0)
        {
            return "No guards configured.";
        }

        var parts = new List<string> { $"Available Guards ({guards.Count}):" };
        foreach (var guard in guards)
        {
            parts.Add(FormatGuard(guard));
            parts.Add("---");
        }

        return string.Join("\n", parts);
    }

    private static string FormatGuard(Guard guard)
    {
        var parts = new List<string>
        {
            $"Guard: {guard.Name} (id: {guard.Id})",
        };

        if (!string.IsNullOrWhiteSpace(guard.Description))
        {
            parts.Add($"Description: {guard.Description}");
        }

        if (guard.Validators is { Count: > 0 })
        {
            parts.Add("Validators:");
            foreach (var validator in guard.Validators)
            {
                var entry = $"  - {validator.Id}";
                if (!string.IsNullOrWhiteSpace(validator.On))
                {
                    entry += $" (on: {validator.On})";
                }

                if (validator.OnFail is not null)
                {
                    entry += $" [onFail: {validator.OnFail}]";
                }

                parts.Add(entry);
            }
        }

        return string.Join("\n", parts);
    }
}

namespace Guardrails.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static GuardrailsClient GetAuthenticatedClient()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("GUARDRAILS_API_KEY") is { Length: > 0 } apiKeyValue
                ? apiKeyValue
                : throw new AssertInconclusiveException("GUARDRAILS_API_KEY environment variable is not found.");

        var baseUrl =
            Environment.GetEnvironmentVariable("GUARDRAILS_BASE_URL") is { Length: > 0 } baseUrlValue
                ? new Uri(baseUrlValue)
                : new Uri(GuardrailsClient.DefaultBaseUrl);

        var client = new GuardrailsClient(apiKey, baseUri: baseUrl);

        return client;
    }
}

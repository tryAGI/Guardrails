namespace Guardrails.IntegrationTests;

/// <summary>
/// What generate.sh does to the spec, checked without an API key.
///
/// generate.sh rewrites the whole document in python3, inlining external $refs the upstream spec
/// leaves dangling. Without it almost nothing generates.
///
/// This SDK passes no `--security-scheme`, so there is no credential to assert; what can be checked
/// is that the fix still produces the surface it exists to produce. Every other test here needs an
/// API key and reports inconclusive without one, so the suite printed `Skipped!` and exited 0 —
/// which reads exactly like a passing run.
/// </summary>
[TestClass]
public class SpecFixContractTests
{
    [TestMethod]
    public void TheSurfaceTheSpecFixProducesIsStillThere()
    {
        Assert.IsNotNull(
            typeof(global::Guardrails.GuardrailsClient).Assembly.GetType("Guardrails.GuardClient", throwOnError: false),
            "Guardrails.GuardClient is gone. It is generated from the document generate.sh produces; " +
            "if a spec refresh removed it, look at the fix rather than at this test.");
    }

    [TestMethod]
    public void TheDefaultBaseUrlIsTheOneTheSpecDeclares()
    {
        Assert.AreEqual("http://localhost:8000/", global::Guardrails.GuardrailsClient.DefaultBaseUrl);
    }
}

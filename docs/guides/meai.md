# Microsoft.Extensions.AI Integration

The Guardrails SDK provides `AIFunction` tools that integrate with any `IChatClient` through the Microsoft.Extensions.AI (MEAI) abstractions.

## Available Tools

| Tool | Method | Description |
|------|--------|-------------|
| `ValidateWithGuard` | `AsValidateTool()` | Validates LLM output against a named Guard |
| `ListGuards` | `AsListGuardsTool()` | Lists all available Guards |
| `GetGuard` | `AsGetGuardTool()` | Gets a specific Guard's configuration |

## Usage

```csharp
using Guardrails;
using Microsoft.Extensions.AI;

// Create the Guardrails client (self-hosted server)
using var guardrailsClient = new GuardrailsClient(apiKey);

// Create tools for use with any IChatClient
var tools = new[]
{
    guardrailsClient.AsValidateTool(),
    guardrailsClient.AsListGuardsTool(),
    guardrailsClient.AsGetGuardTool(),
};

// Use with any IChatClient (OpenAI, Anthropic, Ollama, etc.)
IChatClient chatClient = /* your chat client */;

var response = await chatClient.GetResponseAsync(
    "Validate this text against the 'content-safety' guard: 'Hello world'",
    new ChatOptions { Tools = [..tools] });
```

## Tool Details

### ValidateWithGuard

The primary tool for content validation. It takes a guard name and LLM output text, then returns:

- Whether validation passed or failed
- Validation summaries per validator
- Error spans highlighting problematic content
- Any suggested fixes

```csharp
// With custom re-ask count
var validateTool = guardrailsClient.AsValidateTool(numReasks: 3);
```

### ListGuards

Lists all Guards the user has access to, including their validators and configurations.

### GetGuard

Fetches detailed configuration for a specific Guard by name.

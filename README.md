# Guardrails

[![Nuget package](https://img.shields.io/nuget/vpre/Guardrails)](https://www.nuget.org/packages/Guardrails/)
[![dotnet](https://github.com/tryAGI/Guardrails/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/tryAGI/Guardrails/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/github/license/tryAGI/Guardrails)](https://github.com/tryAGI/Guardrails/blob/main/LICENSE.txt)
[![Discord](https://img.shields.io/discord/1115206893015662663?label=Discord&logo=discord&logoColor=white&color=d82679)](https://discord.gg/Ca2xhfBf3v)

## Features 🔥
- Fully generated C# SDK based on [official Guardrails AI OpenAPI specification](https://raw.githubusercontent.com/guardrails-ai/guardrails-api-client/main/service-specs/guardrails-service-spec.yml) using [AutoSDK](https://github.com/HavenDV/AutoSDK)
- Same day update to support new features
- Updated and supported automatically if there are no breaking changes
- All modern .NET features - nullability, trimming, NativeAOT, etc.
- MEAI `AIFunction` tools for use with any `IChatClient`

### Usage
```csharp
using Guardrails;

// Connect to a self-hosted Guardrails server (default: http://localhost:8000)
using var client = new GuardrailsClient(apiKey);

// Or specify a custom base URL
using var client = new GuardrailsClient(apiKey, baseUri: new Uri("https://my-guardrails-server.example.com"));
```

### Validate LLM Output
```csharp
var result = await client.Validate.ValidateAsync(
    guardName: "my-guard",
    llmOutput: "Some LLM output to validate");

Console.WriteLine($"Validation passed: {result.ValidationPassed}");
```

### List Guards
```csharp
var guards = await client.Guard.GetGuardsAsync();
foreach (var guard in guards)
{
    Console.WriteLine($"Guard: {guard.Name} ({guard.Id})");
}
```

### MEAI Tools
```csharp
using Microsoft.Extensions.AI;

// Use Guardrails as tools with any IChatClient
var tools = new[]
{
    client.AsValidateTool(),
    client.AsListGuardsTool(),
    client.AsGetGuardTool(),
};

var chatOptions = new ChatOptions { Tools = [..tools] };
```

<!-- EXAMPLES:START -->
<!-- EXAMPLES:END -->

## Support

Priority place for bugs: https://github.com/tryAGI/Guardrails/issues  
Priority place for ideas and general questions: https://github.com/tryAGI/Guardrails/discussions  
Discord: https://discord.gg/Ca2xhfBf3v  

## Acknowledgments

![JetBrains logo](https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.png)

This project is supported by JetBrains through the [Open Source Support Program](https://jb.gg/OpenSourceSupport).

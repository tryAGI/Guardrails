# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

C# SDK for the [Guardrails AI](https://guardrailsai.com/) API, auto-generated from the Guardrails OpenAPI specification using [AutoSDK](https://github.com/HavenDV/AutoSDK). Published as a NuGet package under the `tryAGI` organization.

Guardrails AI is an LLM validation platform for detecting hallucination, PII, prompt injection, toxicity, and other content safety concerns. The Guardrails server is **self-hosted** (not a cloud API) — the default base URL is `http://localhost:8000`.

## Build Commands

```bash
# Build the solution
dotnet build Guardrails.slnx

# Build for release (also produces NuGet package)
dotnet build Guardrails.slnx -c Release

# Run integration tests (requires GUARDRAILS_API_KEY env var and a running Guardrails server)
dotnet test src/tests/IntegrationTests/Guardrails.IntegrationTests.csproj

# Regenerate SDK from OpenAPI spec
cd src/libs/Guardrails && ./generate.sh
```

## Architecture

### Code Generation Pipeline

The SDK code is **entirely auto-generated** — do not manually edit files in `src/libs/Guardrails/Generated/`.

1. `src/libs/Guardrails/generate.sh` — downloads the upstream spec, inlines external `$ref` schemas (from `guardrails-ai/interfaces`), adds `servers` + `security` sections, and runs AutoSDK CLI
2. The upstream spec uses external JSON Schema `$ref` links to `raw.githubusercontent.com/guardrails-ai/interfaces/` — the generate script resolves these into a self-contained OpenAPI 3.0.3 spec
3. Auth: HTTP Bearer (JWT) — the upstream spec also supports apiKey auth, but the SDK uses Bearer for simplicity

### Project Layout

| Project | Purpose |
|---------|---------|
| `src/libs/Guardrails/` | Main SDK library (`GuardrailsClient`) |
| `src/libs/Guardrails/Extensions/` | Hand-written MEAI tools (AIFunction wrappers) |
| `src/tests/IntegrationTests/` | Integration tests against a Guardrails server |

### MEAI Integration

The SDK provides `AIFunction` tools for use with any `IChatClient`:

- `AsValidateTool()` — Validate LLM output against a named Guard
- `AsListGuardsTool()` — List all available Guards
- `AsGetGuardTool()` — Get a specific Guard's configuration

### Sub-client Pattern

The generated client uses sub-client accessors:
- `client.Guard.GetGuardsAsync()` — Guard CRUD operations
- `client.Validate.ValidateAsync()` — Run validations
- `client.Openai.OpenaiChatCompletionAsync()` — OpenAI-compatible chat completions through a Guard
- `client.ServiceHealth.HealthCheckAsync()` — Server health check

### Documentation Generation

Tests in `src/tests/IntegrationTests/Examples` are the single source of truth for both test coverage and documentation:
- Each file has a JSDoc header (`order`, `title`, `slug`) consumed by `autosdk docs sync .`
- Comments prefixed with `////` become prose paragraphs in generated docs
- CI workflow (`.github/workflows/mkdocs.yml`) auto-generates `docs/examples/` and populates `EXAMPLES:START/END` markers in README.md, docs/index.md, and mkdocs.yml
- Config: `autosdk.docs.json` points to `src/tests/IntegrationTests/Examples`

### Build Configuration

- **Target:** `net10.0` (single target)
- **Language:** C# preview with nullable reference types
- **Signing:** Strong-named assemblies via `src/key.snk`
- **Versioning:** Semantic versioning from git tags (`v` prefix) via MinVer
- **Analysis:** All .NET analyzers enabled, AOT/trimming compatibility enforced
- **Testing:** MSTest + AwesomeAssertions

### CI/CD

- Uses shared workflows from `HavenDV/workflows` repo
- Dependabot updates NuGet packages weekly (auto-merged)
- Documentation deployed to GitHub Pages via MkDocs Material

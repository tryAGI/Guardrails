
#nullable enable

namespace Guardrails
{
    public partial class OpenaiClient
    {


        private static readonly global::Guardrails.EndPointSecurityRequirement s_OpenaiChatCompletionSecurityRequirement0 =
            new global::Guardrails.EndPointSecurityRequirement
            {
                Authorizations = new global::Guardrails.EndPointAuthorizationRequirement[]
                {                    new global::Guardrails.EndPointAuthorizationRequirement
                    {
                        Type = "Http",
                        Location = "Header",
                        Name = "Bearer",
                        FriendlyName = "Bearer",
                    },
                },
            };
        private static readonly global::Guardrails.EndPointSecurityRequirement[] s_OpenaiChatCompletionSecurityRequirements =
            new global::Guardrails.EndPointSecurityRequirement[]
            {                s_OpenaiChatCompletionSecurityRequirement0,
            };
        partial void PrepareOpenaiChatCompletionArguments(
            global::System.Net.Http.HttpClient httpClient,
            ref string guardName,
            global::Guardrails.OpenAIChatCompletionPayload request);
        partial void PrepareOpenaiChatCompletionRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            string guardName,
            global::Guardrails.OpenAIChatCompletionPayload request);
        partial void ProcessOpenaiChatCompletionResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessOpenaiChatCompletionResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// OpenAI SDK compatible endpoint for Chat Completions
        /// </summary>
        /// <param name="guardName"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Guardrails.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::Guardrails.OpenAIChatCompletion> OpenaiChatCompletionAsync(
            string guardName,

            global::Guardrails.OpenAIChatCompletionPayload request,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareOpenaiChatCompletionArguments(
                httpClient: HttpClient,
                guardName: ref guardName,
                request: request);


            var __authorizations = global::Guardrails.EndPointSecurityResolver.ResolveAuthorizations(
                availableAuthorizations: Authorizations,
                securityRequirements: s_OpenaiChatCompletionSecurityRequirements,
                operationName: "OpenaiChatCompletionAsync");

            var __pathBuilder = new global::Guardrails.PathBuilder(
                path: $"/guards/{guardName}/openai/v1/chat/completions",
                baseUri: HttpClient.BaseAddress);
            var __path = __pathBuilder.ToString();
            using var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Post,
                requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
#if NET6_0_OR_GREATER
            __httpRequest.Version = global::System.Net.HttpVersion.Version11;
            __httpRequest.VersionPolicy = global::System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher;
#endif

            foreach (var __authorization in __authorizations)
            {
                if (__authorization.Type == "Http" ||
                    __authorization.Type == "OAuth2")
                {
                    __httpRequest.Headers.Authorization = new global::System.Net.Http.Headers.AuthenticationHeaderValue(
                        scheme: __authorization.Name,
                        parameter: __authorization.Value);
                }
                else if (__authorization.Type == "ApiKey" &&
                         __authorization.Location == "Header")
                {
                    __httpRequest.Headers.Add(__authorization.Name, __authorization.Value);
                }
            }
            var __httpRequestContentBody = request.ToJson(JsonSerializerContext);
            var __httpRequestContent = new global::System.Net.Http.StringContent(
                content: __httpRequestContentBody,
                encoding: global::System.Text.Encoding.UTF8,
                mediaType: "application/json");
            __httpRequest.Content = __httpRequestContent;

            PrepareRequest(
                client: HttpClient,
                request: __httpRequest);
            PrepareOpenaiChatCompletionRequest(
                httpClient: HttpClient,
                httpRequestMessage: __httpRequest,
                guardName: guardName,
                request: request);

            using var __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            ProcessResponse(
                client: HttpClient,
                response: __response);
            ProcessOpenaiChatCompletionResponse(
                httpClient: HttpClient,
                httpResponseMessage: __response);
            // Unexpected error
            if (!__response.IsSuccessStatusCode)
            {
                string? __content_default = null;
                global::System.Exception? __exception_default = null;
                global::Guardrails.HttpError? __value_default = null;
                try
                {
                    if (ReadResponseAsString)
                    {
                        __content_default = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        __value_default = global::Guardrails.HttpError.FromJson(__content_default, JsonSerializerContext);
                    }
                    else
                    {
                        __content_default = await __response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

                        __value_default = global::Guardrails.HttpError.FromJson(__content_default, JsonSerializerContext);
                    }
                }
                catch (global::System.Exception __ex)
                {
                    __exception_default = __ex;
                }

                throw new global::Guardrails.ApiException<global::Guardrails.HttpError>(
                    message: __content_default ?? __response.ReasonPhrase ?? string.Empty,
                    innerException: __exception_default,
                    statusCode: __response.StatusCode)
                {
                    ResponseBody = __content_default,
                    ResponseObject = __value_default,
                    ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                        __response.Headers,
                        h => h.Key,
                        h => h.Value),
                };
            }

            if (ReadResponseAsString)
            {
                var __content = await __response.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
                    cancellationToken
#endif
                ).ConfigureAwait(false);

                ProcessResponseContent(
                    client: HttpClient,
                    response: __response,
                    content: ref __content);
                ProcessOpenaiChatCompletionResponseContent(
                    httpClient: HttpClient,
                    httpResponseMessage: __response,
                    content: ref __content);

                try
                {
                    __response.EnsureSuccessStatusCode();

                    return
                        global::Guardrails.OpenAIChatCompletion.FromJson(__content, JsonSerializerContext) ??
                        throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");
                }
                catch (global::System.Exception __ex)
                {
                    throw new global::Guardrails.ApiException(
                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                        innerException: __ex,
                        statusCode: __response.StatusCode)
                    {
                        ResponseBody = __content,
                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                            __response.Headers,
                            h => h.Key,
                            h => h.Value),
                    };
                }
            }
            else
            {
                try
                {
                    __response.EnsureSuccessStatusCode();
                    using var __content = await __response.Content.ReadAsStreamAsync(
#if NET5_0_OR_GREATER
                        cancellationToken
#endif
                    ).ConfigureAwait(false);

                    return
                        await global::Guardrails.OpenAIChatCompletion.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
                        throw new global::System.InvalidOperationException("Response deserialization failed.");
                }
                catch (global::System.Exception __ex)
                {
                    string? __content = null;
                    try
                    {
                        __content = await __response.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
                            cancellationToken
#endif
                        ).ConfigureAwait(false);
                    }
                    catch (global::System.Exception)
                    {
                    }

                    throw new global::Guardrails.ApiException(
                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                        innerException: __ex,
                        statusCode: __response.StatusCode)
                    {
                        ResponseBody = __content,
                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                            __response.Headers,
                            h => h.Key,
                            h => h.Value),
                    };
                }
            }
        }
        /// <summary>
        /// OpenAI SDK compatible endpoint for Chat Completions
        /// </summary>
        /// <param name="guardName"></param>
        /// <param name="model">
        /// The model to use for the completion<br/>
        /// Example: gpt-3.5-turbo
        /// </param>
        /// <param name="messages">
        /// The messages to use for the completion
        /// </param>
        /// <param name="maxTokens">
        /// The maximum number of tokens to generate
        /// </param>
        /// <param name="temperature">
        /// The sampling temperature
        /// </param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::Guardrails.OpenAIChatCompletion> OpenaiChatCompletionAsync(
            string guardName,
            string? model = default,
            global::System.Collections.Generic.IList<global::Guardrails.OpenAIChatMessage>? messages = default,
            int? maxTokens = default,
            double? temperature = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Guardrails.OpenAIChatCompletionPayload
            {
                Model = model,
                Messages = messages,
                MaxTokens = maxTokens,
                Temperature = temperature,
            };

            return await OpenaiChatCompletionAsync(
                guardName: guardName,
                request: __request,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
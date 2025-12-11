# AffinidiTdk.CredentialVerificationClient.Api.DefaultApi

All URIs are relative to *https://apse1.api.affinidi.io/ver*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**VerifyCredentials**](DefaultApi.md#verifycredentials) | **POST** /v1/verifier/verify-vcs | Verifying VC |
| [**VerifyCredentialsV2**](DefaultApi.md#verifycredentialsv2) | **POST** /v2/verifier/credentials | Verifying VC |
| [**VerifyPresentation**](DefaultApi.md#verifypresentation) | **POST** /v1/verifier/verify-vp | Verifying VP |
| [**VerifyPresentationV2**](DefaultApi.md#verifypresentationv2) | **POST** /v2/verifier/presentation | Verifying VP |

<a id="verifycredentials"></a>
# **VerifyCredentials**
> VerifyCredentialOutput VerifyCredentials (VerifyCredentialInput verifyCredentialInput)

Verifying VC

Verifying Verifiable Credentials (signatures)  `isValid` - true if all credentials verified `errors` contains list of error messages for invalid credentials.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;

namespace Example
{
    public class VerifyCredentialsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/ver";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var verifyCredentialInput = new VerifyCredentialInput(); // VerifyCredentialInput | VerifyCredentials

            try
            {
                // Verifying VC
                VerifyCredentialOutput result = apiInstance.VerifyCredentials(verifyCredentialInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.VerifyCredentials: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the VerifyCredentialsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Verifying VC
    ApiResponse<VerifyCredentialOutput> response = apiInstance.VerifyCredentialsWithHttpInfo(verifyCredentialInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.VerifyCredentialsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **verifyCredentialInput** | [**VerifyCredentialInput**](VerifyCredentialInput.md) | VerifyCredentials |  |

### Return type

[**VerifyCredentialOutput**](VerifyCredentialOutput.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **400** | BadRequestError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="verifycredentialsv2"></a>
# **VerifyCredentialsV2**
> VerifyCredentialOutput VerifyCredentialsV2 (VerifyCredentialV2Input verifyCredentialV2Input)

Verifying VC

Verifying Verifiable Credentials (signatures)  `isValid` - true if all credentials verified `errors` contains list of error messages for invalid credentials.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;

namespace Example
{
    public class VerifyCredentialsV2Example
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/ver";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var verifyCredentialV2Input = new VerifyCredentialV2Input(); // VerifyCredentialV2Input | Request body for verifying VCs with separate JWT and LDP arrays

            try
            {
                // Verifying VC
                VerifyCredentialOutput result = apiInstance.VerifyCredentialsV2(verifyCredentialV2Input);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.VerifyCredentialsV2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the VerifyCredentialsV2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Verifying VC
    ApiResponse<VerifyCredentialOutput> response = apiInstance.VerifyCredentialsV2WithHttpInfo(verifyCredentialV2Input);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.VerifyCredentialsV2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **verifyCredentialV2Input** | [**VerifyCredentialV2Input**](VerifyCredentialV2Input.md) | Request body for verifying VCs with separate JWT and LDP arrays |  |

### Return type

[**VerifyCredentialOutput**](VerifyCredentialOutput.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **400** | BadRequestError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="verifypresentation"></a>
# **VerifyPresentation**
> VerifyPresentationOutput VerifyPresentation (VerifyPresentationInput verifyPresentationInput)

Verifying VP

Verifying Verifiable Presentation (signatures)  `isValid` - true if presentation verified `error` verificaction error.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;

namespace Example
{
    public class VerifyPresentationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/ver";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var verifyPresentationInput = new VerifyPresentationInput(); // VerifyPresentationInput | VerifyPresentation

            try
            {
                // Verifying VP
                VerifyPresentationOutput result = apiInstance.VerifyPresentation(verifyPresentationInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.VerifyPresentation: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the VerifyPresentationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Verifying VP
    ApiResponse<VerifyPresentationOutput> response = apiInstance.VerifyPresentationWithHttpInfo(verifyPresentationInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.VerifyPresentationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **verifyPresentationInput** | [**VerifyPresentationInput**](VerifyPresentationInput.md) | VerifyPresentation |  |

### Return type

[**VerifyPresentationOutput**](VerifyPresentationOutput.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **400** | BadRequestError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="verifypresentationv2"></a>
# **VerifyPresentationV2**
> VerifyPresentationOutput VerifyPresentationV2 (VerifyPresentationV2Input verifyPresentationV2Input)

Verifying VP

Verifying Verifiable Presentation (signatures)  Uses Presentation Exchange Query (pexQuery) structure for presentation definition and submission. Supports optional domain and challenge verification as per W3C VP standard.  `isValid` - true if presentation verified `error` verificaction error.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.CredentialVerificationClient.Api;
using AffinidiTdk.CredentialVerificationClient.Client;
using AffinidiTdk.CredentialVerificationClient.Model;

namespace Example
{
    public class VerifyPresentationV2Example
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/ver";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var verifyPresentationV2Input = new VerifyPresentationV2Input(); // VerifyPresentationV2Input | VerifyPresentationV2

            try
            {
                // Verifying VP
                VerifyPresentationOutput result = apiInstance.VerifyPresentationV2(verifyPresentationV2Input);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.VerifyPresentationV2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the VerifyPresentationV2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Verifying VP
    ApiResponse<VerifyPresentationOutput> response = apiInstance.VerifyPresentationV2WithHttpInfo(verifyPresentationV2Input);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.VerifyPresentationV2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **verifyPresentationV2Input** | [**VerifyPresentationV2Input**](VerifyPresentationV2Input.md) | VerifyPresentationV2 |  |

### Return type

[**VerifyPresentationOutput**](VerifyPresentationOutput.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **400** | BadRequestError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


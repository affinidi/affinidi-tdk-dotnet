# AffinidiTdk.CredentialVerificationClient.Api.VerifierApi

All URIs are relative to *https://apse1.api.affinidi.io/ver*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ValidateJwt**](VerifierApi.md#validatejwt) | **POST** /v1/verifier/validate-jwt | Validates JWT token |

<a id="validatejwt"></a>
# **ValidateJwt**
> ValidateJwtOutput ValidateJwt (ValidateJwtInput validateJwtInput)

Validates JWT token

Validates JWT object.  returns   isValid: boolean   payload: payload from JWT

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
    public class ValidateJwtExample
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
            var apiInstance = new VerifierApi(httpClient, config, httpClientHandler);
            var validateJwtInput = new ValidateJwtInput(); // ValidateJwtInput | ValidateJwt

            try
            {
                // Validates JWT token
                ValidateJwtOutput result = apiInstance.ValidateJwt(validateJwtInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VerifierApi.ValidateJwt: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ValidateJwtWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Validates JWT token
    ApiResponse<ValidateJwtOutput> response = apiInstance.ValidateJwtWithHttpInfo(validateJwtInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VerifierApi.ValidateJwtWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **validateJwtInput** | [**ValidateJwtInput**](ValidateJwtInput.md) | ValidateJwt |  |

### Return type

[**ValidateJwtOutput**](ValidateJwtOutput.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | BadRequestError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


# AffinidiTdk.CredentialIssuanceClient.Api.WellKnownApi

All URIs are relative to *https://apse1.api.affinidi.io/cis*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetWellKnownOpenIdCredentialIssuer**](WellKnownApi.md#getwellknownopenidcredentialissuer) | **GET** /v1/{projectId}/.well-known/openid-credential-issuer |  |

<a id="getwellknownopenidcredentialissuer"></a>
# **GetWellKnownOpenIdCredentialIssuer**
> WellKnownOpenIdCredentialIssuerResponse GetWellKnownOpenIdCredentialIssuer (string projectId)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.CredentialIssuanceClient.Api;
using AffinidiTdk.CredentialIssuanceClient.Client;
using AffinidiTdk.CredentialIssuanceClient.Model;

namespace Example
{
    public class GetWellKnownOpenIdCredentialIssuerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cis";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new WellKnownApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | Affinidi project id

            try
            {
                WellKnownOpenIdCredentialIssuerResponse result = apiInstance.GetWellKnownOpenIdCredentialIssuer(projectId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WellKnownApi.GetWellKnownOpenIdCredentialIssuer: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetWellKnownOpenIdCredentialIssuerWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<WellKnownOpenIdCredentialIssuerResponse> response = apiInstance.GetWellKnownOpenIdCredentialIssuerWithHttpInfo(projectId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WellKnownApi.GetWellKnownOpenIdCredentialIssuerWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** | Affinidi project id |  |

### Return type

[**WellKnownOpenIdCredentialIssuerResponse**](WellKnownOpenIdCredentialIssuerResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Credential issuer Metadata and capabilities |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


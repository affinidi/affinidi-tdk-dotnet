# AffinidiTdk.ConsumerIamClient.Api.ConsumerAuthApi

All URIs are relative to *https://apse1.api.affinidi.io/cid*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ConsumerAuthTokenEndpoint**](ConsumerAuthApi.md#consumerauthtokenendpoint) | **POST** /v1/consumer/oauth2/token | The Consumer OAuth 2.0 Token Endpoint |

<a id="consumerauthtokenendpoint"></a>
# **ConsumerAuthTokenEndpoint**
> ConsumerAuthTokenEndpointOutput ConsumerAuthTokenEndpoint (ConsumerAuthTokenEndpointInput consumerAuthTokenEndpointInput)

The Consumer OAuth 2.0 Token Endpoint

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.ConsumerIamClient.Api;
using AffinidiTdk.ConsumerIamClient.Client;
using AffinidiTdk.ConsumerIamClient.Model;

namespace Example
{
    public class ConsumerAuthTokenEndpointExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cid";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ConsumerAuthApi(httpClient, config, httpClientHandler);
            var consumerAuthTokenEndpointInput = new ConsumerAuthTokenEndpointInput(); // ConsumerAuthTokenEndpointInput | ConsumerAuthTokenEndpoint

            try
            {
                // The Consumer OAuth 2.0 Token Endpoint
                ConsumerAuthTokenEndpointOutput result = apiInstance.ConsumerAuthTokenEndpoint(consumerAuthTokenEndpointInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConsumerAuthApi.ConsumerAuthTokenEndpoint: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ConsumerAuthTokenEndpointWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // The Consumer OAuth 2.0 Token Endpoint
    ApiResponse<ConsumerAuthTokenEndpointOutput> response = apiInstance.ConsumerAuthTokenEndpointWithHttpInfo(consumerAuthTokenEndpointInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConsumerAuthApi.ConsumerAuthTokenEndpointWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **consumerAuthTokenEndpointInput** | [**ConsumerAuthTokenEndpointInput**](ConsumerAuthTokenEndpointInput.md) | ConsumerAuthTokenEndpoint |  |

### Return type

[**ConsumerAuthTokenEndpointOutput**](ConsumerAuthTokenEndpointOutput.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Consumer Token OK Response |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **401** | UnauthorizedError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **403** | ForbiddenError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **500** | UnexpectedError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


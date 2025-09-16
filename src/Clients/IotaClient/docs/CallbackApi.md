# AffinidiTdk.IotaClient.Api.CallbackApi

All URIs are relative to *https://apse1.api.affinidi.io/ais*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**IotOIDC4VPCallback**](CallbackApi.md#iotoidc4vpcallback) | **POST** /v1/callback |  |

<a id="iotoidc4vpcallback"></a>
# **IotOIDC4VPCallback**
> CallbackResponseOK IotOIDC4VPCallback (CallbackInput callbackInput)



It handles the client's (e.g., Affinidi Vault) callback about the result of the data-sharing request. It may contain the data shared by the user, including the presentation submission, verification token, and state. Using the MQTT protocol, it communicates the completion of the request or if any error occurred. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.IotaClient.Api;
using AffinidiTdk.IotaClient.Client;
using AffinidiTdk.IotaClient.Model;

namespace Example
{
    public class IotOIDC4VPCallbackExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/ais";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new CallbackApi(httpClient, config, httpClientHandler);
            var callbackInput = new CallbackInput(); // CallbackInput | CallbackRequestInput

            try
            {
                CallbackResponseOK result = apiInstance.IotOIDC4VPCallback(callbackInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CallbackApi.IotOIDC4VPCallback: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the IotOIDC4VPCallbackWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<CallbackResponseOK> response = apiInstance.IotOIDC4VPCallbackWithHttpInfo(callbackInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CallbackApi.IotOIDC4VPCallbackWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **callbackInput** | [**CallbackInput**](CallbackInput.md) | CallbackRequestInput |  |

### Return type

[**CallbackResponseOK**](CallbackResponseOK.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | CallbackResponseOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **403** | ForbiddenError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


# AffinidiTdk.IotaClient.Api.DefaultApi

All URIs are relative to *https://apse1.api.affinidi.io/ais*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ListLoggedConsents**](DefaultApi.md#listloggedconsents) | **GET** /v1/logged-consents |  |

<a id="listloggedconsents"></a>
# **ListLoggedConsents**
> ListLoggedConsentsOK ListLoggedConsents (string? configurationId = null, string? userId = null, int? limit = null, string? exclusiveStartKey = null)



Lists all the logged consents for a project.

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
    public class ListLoggedConsentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/ais";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string? |  (optional) 
            var userId = "userId_example";  // string? |  (optional) 
            var limit = 56;  // int? | The maximum number of records to fetch from the list of logged consents. (optional) 
            var exclusiveStartKey = "exclusiveStartKey_example";  // string? | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. (optional) 

            try
            {
                ListLoggedConsentsOK result = apiInstance.ListLoggedConsents(configurationId, userId, limit, exclusiveStartKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.ListLoggedConsents: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListLoggedConsentsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ListLoggedConsentsOK> response = apiInstance.ListLoggedConsentsWithHttpInfo(configurationId, userId, limit, exclusiveStartKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.ListLoggedConsentsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string?** |  | [optional]  |
| **userId** | **string?** |  | [optional]  |
| **limit** | **int?** | The maximum number of records to fetch from the list of logged consents. | [optional]  |
| **exclusiveStartKey** | **string?** | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. | [optional]  |

### Return type

[**ListLoggedConsentsOK**](ListLoggedConsentsOK.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | ListLoggedConsentsOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


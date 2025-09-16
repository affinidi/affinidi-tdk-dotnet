# AffinidiTdk.VaultDataManagerClient.Api.WellKnownApi

All URIs are relative to *https://api.vault.affinidi.com/vfs*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetWellKnownJwks**](WellKnownApi.md#getwellknownjwks) | **GET** /.well-known/jwks.json |  |

<a id="getwellknownjwks"></a>
# **GetWellKnownJwks**
> JsonWebKeySetDto GetWellKnownJwks ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.VaultDataManagerClient.Api;
using AffinidiTdk.VaultDataManagerClient.Client;
using AffinidiTdk.VaultDataManagerClient.Model;

namespace Example
{
    public class GetWellKnownJwksExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.vault.affinidi.com/vfs";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new WellKnownApi(httpClient, config, httpClientHandler);

            try
            {
                JsonWebKeySetDto result = apiInstance.GetWellKnownJwks();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WellKnownApi.GetWellKnownJwks: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetWellKnownJwksWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<JsonWebKeySetDto> response = apiInstance.GetWellKnownJwksWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WellKnownApi.GetWellKnownJwksWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**JsonWebKeySetDto**](JsonWebKeySetDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | List of JWK used by the services as JWKS |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **500** | UnexpectedError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


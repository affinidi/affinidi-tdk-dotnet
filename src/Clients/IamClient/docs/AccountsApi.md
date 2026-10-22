# AffinidiTdk.IamClient.Api.AccountsApi

All URIs are relative to *https://apse1.api.affinidi.io/iam*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ListAccountPasskeys**](AccountsApi.md#listaccountpasskeys) | **GET** /v1/accounts/passkeys |  |
| [**ListAccountProviders**](AccountsApi.md#listaccountproviders) | **GET** /v1/accounts/providers |  |

<a id="listaccountpasskeys"></a>
# **ListAccountPasskeys**
> PasskeyList ListAccountPasskeys ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.IamClient.Api;
using AffinidiTdk.IamClient.Client;
using AffinidiTdk.IamClient.Model;

namespace Example
{
    public class ListAccountPasskeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/iam";
            // Configure API key authorization: UserTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new AccountsApi(httpClient, config, httpClientHandler);

            try
            {
                PasskeyList result = apiInstance.ListAccountPasskeys();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountsApi.ListAccountPasskeys: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListAccountPasskeysWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<PasskeyList> response = apiInstance.ListAccountPasskeysWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountsApi.ListAccountPasskeysWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**PasskeyList**](PasskeyList.md)

### Authorization

[UserTokenAuth](../README.md#UserTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Registered passkeys for the authenticated account |  * Cache-Control - Always no-store; account authentication methods must not be cached <br>  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |
| **422** | UnprocessableEntity |  -  |
| **424** | FailedDependencyError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listaccountproviders"></a>
# **ListAccountProviders**
> ProviderList ListAccountProviders ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.IamClient.Api;
using AffinidiTdk.IamClient.Client;
using AffinidiTdk.IamClient.Model;

namespace Example
{
    public class ListAccountProvidersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/iam";
            // Configure API key authorization: UserTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new AccountsApi(httpClient, config, httpClientHandler);

            try
            {
                ProviderList result = apiInstance.ListAccountProviders();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountsApi.ListAccountProviders: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListAccountProvidersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ProviderList> response = apiInstance.ListAccountProvidersWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountsApi.ListAccountProvidersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ProviderList**](ProviderList.md)

### Authorization

[UserTokenAuth](../README.md#UserTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Linked and unlinked social providers for the authenticated account |  * Cache-Control - Always no-store; account authentication methods must not be cached <br>  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |
| **422** | UnprocessableEntity |  -  |
| **424** | FailedDependencyError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


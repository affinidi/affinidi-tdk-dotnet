# AffinidiTdk.VaultDataManagerClient.Api.ProfileDataApi

All URIs are relative to *https://api.vault.affinidi.com/vfs*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**QueryProfileData**](ProfileDataApi.md#queryprofiledata) | **GET** /v1/nodes/{nodeId}/profile-data |  |
| [**UpdateProfileData**](ProfileDataApi.md#updateprofiledata) | **PATCH** /v1/nodes/{nodeId}/profile-data |  |

<a id="queryprofiledata"></a>
# **QueryProfileData**
> QueryProfileDataOK QueryProfileData (string nodeId, string dek, string? query = null)



Retrieves information from a profile.

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
    public class QueryProfileDataExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.vault.affinidi.com/vfs";
            // Configure API key authorization: ConsumerTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ProfileDataApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | the nodeId of the node being operated on
            var dek = "dek_example";  // string | A base64url encoded data encryption key, encrypted using VFS public
            var query = "query_example";  // string? | data query, TBD maybe encode it with base64 to make it url friendly? (optional) 

            try
            {
                QueryProfileDataOK result = apiInstance.QueryProfileData(nodeId, dek, query);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProfileDataApi.QueryProfileData: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the QueryProfileDataWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<QueryProfileDataOK> response = apiInstance.QueryProfileDataWithHttpInfo(nodeId, dek, query);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ProfileDataApi.QueryProfileDataWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** | the nodeId of the node being operated on |  |
| **dek** | **string** | A base64url encoded data encryption key, encrypted using VFS public |  |
| **query** | **string?** | data query, TBD maybe encode it with base64 to make it url friendly? | [optional]  |

### Return type

[**QueryProfileDataOK**](QueryProfileDataOK.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | QueryProfileDataOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateprofiledata"></a>
# **UpdateProfileData**
> UpdateProfileDataOK UpdateProfileData (string nodeId, UpdateProfileDataInput updateProfileDataInput)



Updates the profile with the given data

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
    public class UpdateProfileDataExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.vault.affinidi.com/vfs";
            // Configure API key authorization: ConsumerTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ProfileDataApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | 
            var updateProfileDataInput = new UpdateProfileDataInput(); // UpdateProfileDataInput | Updates the schema with the given data

            try
            {
                UpdateProfileDataOK result = apiInstance.UpdateProfileData(nodeId, updateProfileDataInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ProfileDataApi.UpdateProfileData: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateProfileDataWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<UpdateProfileDataOK> response = apiInstance.UpdateProfileDataWithHttpInfo(nodeId, updateProfileDataInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ProfileDataApi.UpdateProfileDataWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** |  |  |
| **updateProfileDataInput** | [**UpdateProfileDataInput**](UpdateProfileDataInput.md) | Updates the schema with the given data |  |

### Return type

[**UpdateProfileDataOK**](UpdateProfileDataOK.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | UpdateSchemaOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


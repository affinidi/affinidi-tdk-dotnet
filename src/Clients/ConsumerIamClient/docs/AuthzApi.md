# AffinidiTdk.ConsumerIamClient.Api.AuthzApi

All URIs are relative to *https://apse1.api.affinidi.io/cid*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteAccessVfs**](AuthzApi.md#deleteaccessvfs) | **DELETE** /v1/authz/vfs/access/{granteeDid} | delete access of granteeDid |
| [**GetAccessVfs**](AuthzApi.md#getaccessvfs) | **GET** /v1/authz/vfs/access/{granteeDid} | Get permissions to the virtual file system for a subject |
| [**GrantAccessVfs**](AuthzApi.md#grantaccessvfs) | **POST** /v1/authz/vfs/access/{granteeDid} | Grant access to the virtual file system |
| [**UpdateAccessVfs**](AuthzApi.md#updateaccessvfs) | **PUT** /v1/authz/vfs/access/{granteeDid} | Update access of granteeDid |

<a id="deleteaccessvfs"></a>
# **DeleteAccessVfs**
> void DeleteAccessVfs (string granteeDid)

delete access of granteeDid

deleteAccessVfs

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
    public class DeleteAccessVfsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cid";
            // Configure API key authorization: ConsumerTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new AuthzApi(httpClient, config, httpClientHandler);
            var granteeDid = "granteeDid_example";  // string | 

            try
            {
                // delete access of granteeDid
                apiInstance.DeleteAccessVfs(granteeDid);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthzApi.DeleteAccessVfs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteAccessVfsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // delete access of granteeDid
    apiInstance.DeleteAccessVfsWithHttpInfo(granteeDid);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthzApi.DeleteAccessVfsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **granteeDid** | **string** |  |  |

### Return type

void (empty response body)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Ok |  -  |
| **403** | ForbiddenError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getaccessvfs"></a>
# **GetAccessVfs**
> GetAccessOutput GetAccessVfs (string granteeDid)

Get permissions to the virtual file system for a subject

Retrieves access rights granted to a subject for the virtual file system

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
    public class GetAccessVfsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cid";
            // Configure API key authorization: ConsumerTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new AuthzApi(httpClient, config, httpClientHandler);
            var granteeDid = "granteeDid_example";  // string | 

            try
            {
                // Get permissions to the virtual file system for a subject
                GetAccessOutput result = apiInstance.GetAccessVfs(granteeDid);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthzApi.GetAccessVfs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAccessVfsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get permissions to the virtual file system for a subject
    ApiResponse<GetAccessOutput> response = apiInstance.GetAccessVfsWithHttpInfo(granteeDid);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthzApi.GetAccessVfsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **granteeDid** | **string** |  |  |

### Return type

[**GetAccessOutput**](GetAccessOutput.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved access permissions for the subject |  -  |
| **403** | ForbiddenError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="grantaccessvfs"></a>
# **GrantAccessVfs**
> GrantAccessOutput GrantAccessVfs (string granteeDid, GrantAccessInput grantAccessInput)

Grant access to the virtual file system

Grants access rights to a subject for the virtual file system

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
    public class GrantAccessVfsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cid";
            // Configure API key authorization: ConsumerTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new AuthzApi(httpClient, config, httpClientHandler);
            var granteeDid = "granteeDid_example";  // string | 
            var grantAccessInput = new GrantAccessInput(); // GrantAccessInput | Grant access to virtual file system

            try
            {
                // Grant access to the virtual file system
                GrantAccessOutput result = apiInstance.GrantAccessVfs(granteeDid, grantAccessInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthzApi.GrantAccessVfs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GrantAccessVfsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Grant access to the virtual file system
    ApiResponse<GrantAccessOutput> response = apiInstance.GrantAccessVfsWithHttpInfo(granteeDid, grantAccessInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthzApi.GrantAccessVfsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **granteeDid** | **string** |  |  |
| **grantAccessInput** | [**GrantAccessInput**](GrantAccessInput.md) | Grant access to virtual file system |  |

### Return type

[**GrantAccessOutput**](GrantAccessOutput.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully granted access to Service |  -  |
| **403** | ForbiddenError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateaccessvfs"></a>
# **UpdateAccessVfs**
> UpdateAccessOutput UpdateAccessVfs (string granteeDid, UpdateAccessInput updateAccessInput)

Update access of granteeDid

updateAccessVfs

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
    public class UpdateAccessVfsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cid";
            // Configure API key authorization: ConsumerTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new AuthzApi(httpClient, config, httpClientHandler);
            var granteeDid = "granteeDid_example";  // string | 
            var updateAccessInput = new UpdateAccessInput(); // UpdateAccessInput | update access to virtual file system

            try
            {
                // Update access of granteeDid
                UpdateAccessOutput result = apiInstance.UpdateAccessVfs(granteeDid, updateAccessInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthzApi.UpdateAccessVfs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateAccessVfsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update access of granteeDid
    ApiResponse<UpdateAccessOutput> response = apiInstance.UpdateAccessVfsWithHttpInfo(granteeDid, updateAccessInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthzApi.UpdateAccessVfsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **granteeDid** | **string** |  |  |
| **updateAccessInput** | [**UpdateAccessInput**](UpdateAccessInput.md) | update access to virtual file system |  |

### Return type

[**UpdateAccessOutput**](UpdateAccessOutput.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully updated access to Service |  -  |
| **403** | ForbiddenError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


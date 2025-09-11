# AffinidiTdk.IamClient.Api.TokensApi

All URIs are relative to *https://apse1.api.affinidi.io/iam*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateToken**](TokensApi.md#createtoken) | **POST** /v1/tokens |  |
| [**DeleteToken**](TokensApi.md#deletetoken) | **DELETE** /v1/tokens/{tokenId} |  |
| [**GetToken**](TokensApi.md#gettoken) | **GET** /v1/tokens/{tokenId} |  |
| [**ListProjectsOfToken**](TokensApi.md#listprojectsoftoken) | **GET** /v1/tokens/{tokenId}/projects |  |
| [**ListToken**](TokensApi.md#listtoken) | **GET** /v1/tokens |  |
| [**UpdateToken**](TokensApi.md#updatetoken) | **PATCH** /v1/tokens/{tokenId} |  |

<a id="createtoken"></a>
# **CreateToken**
> TokenDto CreateToken (CreateTokenInput createTokenInput)



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
    public class CreateTokenExample
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
            var apiInstance = new TokensApi(httpClient, config, httpClientHandler);
            var createTokenInput = new CreateTokenInput(); // CreateTokenInput | CreateToken

            try
            {
                TokenDto result = apiInstance.CreateToken(createTokenInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TokensApi.CreateToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TokenDto> response = apiInstance.CreateTokenWithHttpInfo(createTokenInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TokensApi.CreateTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createTokenInput** | [**CreateTokenInput**](CreateTokenInput.md) | CreateToken |  |

### Return type

[**TokenDto**](TokenDto.md)

### Authorization

[UserTokenAuth](../README.md#UserTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Created Token |  -  |
| **400** | BadRequestError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletetoken"></a>
# **DeleteToken**
> void DeleteToken (Guid tokenId)



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
    public class DeleteTokenExample
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
            var apiInstance = new TokensApi(httpClient, config, httpClientHandler);
            var tokenId = "tokenId_example";  // Guid | 

            try
            {
                apiInstance.DeleteToken(tokenId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TokensApi.DeleteToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.DeleteTokenWithHttpInfo(tokenId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TokensApi.DeleteTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tokenId** | **Guid** |  |  |

### Return type

void (empty response body)

### Authorization

[UserTokenAuth](../README.md#UserTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Token Deleted |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="gettoken"></a>
# **GetToken**
> TokenDto GetToken (Guid tokenId)



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
    public class GetTokenExample
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
            var apiInstance = new TokensApi(httpClient, config, httpClientHandler);
            var tokenId = "tokenId_example";  // Guid | 

            try
            {
                TokenDto result = apiInstance.GetToken(tokenId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TokensApi.GetToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TokenDto> response = apiInstance.GetTokenWithHttpInfo(tokenId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TokensApi.GetTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tokenId** | **Guid** |  |  |

### Return type

[**TokenDto**](TokenDto.md)

### Authorization

[UserTokenAuth](../README.md#UserTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Token |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listprojectsoftoken"></a>
# **ListProjectsOfToken**
> ProjectWithPolicyList ListProjectsOfToken (Guid tokenId, int? limit = null, string? exclusiveStartKey = null)



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
    public class ListProjectsOfTokenExample
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
            var apiInstance = new TokensApi(httpClient, config, httpClientHandler);
            var tokenId = "tokenId_example";  // Guid | 
            var limit = 100;  // int? | Maximum number of records to fetch in a list (optional)  (default to 100)
            var exclusiveStartKey = "exclusiveStartKey_example";  // string? | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. (optional) 

            try
            {
                ProjectWithPolicyList result = apiInstance.ListProjectsOfToken(tokenId, limit, exclusiveStartKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TokensApi.ListProjectsOfToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListProjectsOfTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ProjectWithPolicyList> response = apiInstance.ListProjectsOfTokenWithHttpInfo(tokenId, limit, exclusiveStartKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TokensApi.ListProjectsOfTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tokenId** | **Guid** |  |  |
| **limit** | **int?** | Maximum number of records to fetch in a list | [optional] [default to 100] |
| **exclusiveStartKey** | **string?** | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. | [optional]  |

### Return type

[**ProjectWithPolicyList**](ProjectWithPolicyList.md)

### Authorization

[UserTokenAuth](../README.md#UserTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listtoken"></a>
# **ListToken**
> TokenList ListToken (int? limit = null, string? exclusiveStartKey = null)



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
    public class ListTokenExample
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
            var apiInstance = new TokensApi(httpClient, config, httpClientHandler);
            var limit = 100;  // int? | Maximum number of records to fetch in a list (optional)  (default to 100)
            var exclusiveStartKey = "exclusiveStartKey_example";  // string? | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. (optional) 

            try
            {
                TokenList result = apiInstance.ListToken(limit, exclusiveStartKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TokensApi.ListToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TokenList> response = apiInstance.ListTokenWithHttpInfo(limit, exclusiveStartKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TokensApi.ListTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **limit** | **int?** | Maximum number of records to fetch in a list | [optional] [default to 100] |
| **exclusiveStartKey** | **string?** | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. | [optional]  |

### Return type

[**TokenList**](TokenList.md)

### Authorization

[UserTokenAuth](../README.md#UserTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | List of Tokens |  -  |
| **400** | BadRequestError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatetoken"></a>
# **UpdateToken**
> TokenDto UpdateToken (Guid tokenId, UpdateTokenInput updateTokenInput)



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
    public class UpdateTokenExample
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
            var apiInstance = new TokensApi(httpClient, config, httpClientHandler);
            var tokenId = "tokenId_example";  // Guid | 
            var updateTokenInput = new UpdateTokenInput(); // UpdateTokenInput | UpdateToken

            try
            {
                TokenDto result = apiInstance.UpdateToken(tokenId, updateTokenInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TokensApi.UpdateToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<TokenDto> response = apiInstance.UpdateTokenWithHttpInfo(tokenId, updateTokenInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TokensApi.UpdateTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tokenId** | **Guid** |  |  |
| **updateTokenInput** | [**UpdateTokenInput**](UpdateTokenInput.md) | UpdateToken |  |

### Return type

[**TokenDto**](TokenDto.md)

### Authorization

[UserTokenAuth](../README.md#UserTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated Token |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |
| **500** | UnexpectedError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


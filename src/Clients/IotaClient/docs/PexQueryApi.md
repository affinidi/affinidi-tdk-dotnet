# AffinidiTdk.IotaClient.Api.PexQueryApi

All URIs are relative to *https://apse1.api.affinidi.io/ais*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreatePexQuery**](PexQueryApi.md#createpexquery) | **POST** /v1/configurations/{configurationId}/pex-queries |  |
| [**DeletePexQueries**](PexQueryApi.md#deletepexqueries) | **POST** /v1/configurations/{configurationId}/delete-queries |  |
| [**DeletePexQueryById**](PexQueryApi.md#deletepexquerybyid) | **DELETE** /v1/configurations/{configurationId}/pex-queries/{queryId} |  |
| [**GetPexQueryById**](PexQueryApi.md#getpexquerybyid) | **GET** /v1/configurations/{configurationId}/pex-queries/{queryId} |  |
| [**ListPexQueries**](PexQueryApi.md#listpexqueries) | **GET** /v1/configurations/{configurationId}/pex-queries |  |
| [**SavePexQueries**](PexQueryApi.md#savepexqueries) | **POST** /v1/configurations/{configurationId}/save-queries |  |
| [**UpdatePexQueryById**](PexQueryApi.md#updatepexquerybyid) | **PATCH** /v1/configurations/{configurationId}/pex-queries/{queryId} |  |

<a id="createpexquery"></a>
# **CreatePexQuery**
> PexQueryDto CreatePexQuery (string configurationId, CreatePexQueryInput createPexQueryInput)



Creates a new Presentation Definition in the configuration to query data.

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
    public class CreatePexQueryExample
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
            var apiInstance = new PexQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var createPexQueryInput = new CreatePexQueryInput(); // CreatePexQueryInput | CreatePexQuery

            try
            {
                PexQueryDto result = apiInstance.CreatePexQuery(configurationId, createPexQueryInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PexQueryApi.CreatePexQuery: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreatePexQueryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<PexQueryDto> response = apiInstance.CreatePexQueryWithHttpInfo(configurationId, createPexQueryInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PexQueryApi.CreatePexQueryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | ID of the Affinidi Iota Framework configuration. |  |
| **createPexQueryInput** | [**CreatePexQueryInput**](CreatePexQueryInput.md) | CreatePexQuery |  |

### Return type

[**PexQueryDto**](PexQueryDto.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | CreatePexQueryOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |
| **409** | ConflictError |  -  |
| **422** | UnprocessableEntity |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletepexqueries"></a>
# **DeletePexQueries**
> Object DeletePexQueries (string configurationId, DeletePexQueriesInput deletePexQueriesInput)



Deletes all Presentation Definition queries of a configuration.

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
    public class DeletePexQueriesExample
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
            var apiInstance = new PexQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var deletePexQueriesInput = new DeletePexQueriesInput(); // DeletePexQueriesInput | DeletePexQueriesInput

            try
            {
                Object result = apiInstance.DeletePexQueries(configurationId, deletePexQueriesInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PexQueryApi.DeletePexQueries: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeletePexQueriesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Object> response = apiInstance.DeletePexQueriesWithHttpInfo(configurationId, deletePexQueriesInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PexQueryApi.DeletePexQueriesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | ID of the Affinidi Iota Framework configuration. |  |
| **deletePexQueriesInput** | [**DeletePexQueriesInput**](DeletePexQueriesInput.md) | DeletePexQueriesInput |  |

### Return type

**Object**

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | BulkDeleteResponseOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletepexquerybyid"></a>
# **DeletePexQueryById**
> void DeletePexQueryById (string configurationId, string queryId)



Deletes a Presentation Definition in the configuration by ID.

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
    public class DeletePexQueryByIdExample
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
            var apiInstance = new PexQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var queryId = "queryId_example";  // string | The ID of the query.

            try
            {
                apiInstance.DeletePexQueryById(configurationId, queryId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PexQueryApi.DeletePexQueryById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeletePexQueryByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.DeletePexQueryByIdWithHttpInfo(configurationId, queryId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PexQueryApi.DeletePexQueryByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | ID of the Affinidi Iota Framework configuration. |  |
| **queryId** | **string** | The ID of the query. |  |

### Return type

void (empty response body)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Deleted |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getpexquerybyid"></a>
# **GetPexQueryById**
> PexQueryDto GetPexQueryById (string configurationId, string queryId)



Retrieves a Presentation Definition in the configuration by ID.

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
    public class GetPexQueryByIdExample
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
            var apiInstance = new PexQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var queryId = "queryId_example";  // string | The ID of the query.

            try
            {
                PexQueryDto result = apiInstance.GetPexQueryById(configurationId, queryId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PexQueryApi.GetPexQueryById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPexQueryByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<PexQueryDto> response = apiInstance.GetPexQueryByIdWithHttpInfo(configurationId, queryId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PexQueryApi.GetPexQueryByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | ID of the Affinidi Iota Framework configuration. |  |
| **queryId** | **string** | The ID of the query. |  |

### Return type

[**PexQueryDto**](PexQueryDto.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | GetPexQueryByIdOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listpexqueries"></a>
# **ListPexQueries**
> ListPexQueriesOK ListPexQueries (string configurationId, int? limit = null, string? exclusiveStartKey = null)



Lists all Presentation Definitions in the configuration.

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
    public class ListPexQueriesExample
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
            var apiInstance = new PexQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var limit = 56;  // int? | Maximum number of records to fetch in a list (optional) 
            var exclusiveStartKey = "exclusiveStartKey_example";  // string? | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. (optional) 

            try
            {
                ListPexQueriesOK result = apiInstance.ListPexQueries(configurationId, limit, exclusiveStartKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PexQueryApi.ListPexQueries: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListPexQueriesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ListPexQueriesOK> response = apiInstance.ListPexQueriesWithHttpInfo(configurationId, limit, exclusiveStartKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PexQueryApi.ListPexQueriesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | ID of the Affinidi Iota Framework configuration. |  |
| **limit** | **int?** | Maximum number of records to fetch in a list | [optional]  |
| **exclusiveStartKey** | **string?** | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. | [optional]  |

### Return type

[**ListPexQueriesOK**](ListPexQueriesOK.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | ListPexQueriesOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="savepexqueries"></a>
# **SavePexQueries**
> Object SavePexQueries (string configurationId, SavePexQueriesUpdateInput savePexQueriesUpdateInput)



Saves all Presentation Definition queries of a configuration.

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
    public class SavePexQueriesExample
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
            var apiInstance = new PexQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var savePexQueriesUpdateInput = new SavePexQueriesUpdateInput(); // SavePexQueriesUpdateInput | SavePexQueriesInput

            try
            {
                Object result = apiInstance.SavePexQueries(configurationId, savePexQueriesUpdateInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PexQueryApi.SavePexQueries: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SavePexQueriesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<Object> response = apiInstance.SavePexQueriesWithHttpInfo(configurationId, savePexQueriesUpdateInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PexQueryApi.SavePexQueriesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | ID of the Affinidi Iota Framework configuration. |  |
| **savePexQueriesUpdateInput** | [**SavePexQueriesUpdateInput**](SavePexQueriesUpdateInput.md) | SavePexQueriesInput |  |

### Return type

**Object**

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | SavePexQueriesResponseOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatepexquerybyid"></a>
# **UpdatePexQueryById**
> PexQueryDto UpdatePexQueryById (string configurationId, string queryId, UpdatePexQueryInput updatePexQueryInput)



Updates the Presentation Definition in the configuration by ID.

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
    public class UpdatePexQueryByIdExample
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
            var apiInstance = new PexQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var queryId = "queryId_example";  // string | The ID of the query.
            var updatePexQueryInput = new UpdatePexQueryInput(); // UpdatePexQueryInput | UpdatePexQueryById

            try
            {
                PexQueryDto result = apiInstance.UpdatePexQueryById(configurationId, queryId, updatePexQueryInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PexQueryApi.UpdatePexQueryById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdatePexQueryByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<PexQueryDto> response = apiInstance.UpdatePexQueryByIdWithHttpInfo(configurationId, queryId, updatePexQueryInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PexQueryApi.UpdatePexQueryByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | ID of the Affinidi Iota Framework configuration. |  |
| **queryId** | **string** | The ID of the query. |  |
| **updatePexQueryInput** | [**UpdatePexQueryInput**](UpdatePexQueryInput.md) | UpdatePexQueryById |  |

### Return type

[**PexQueryDto**](PexQueryDto.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | UpdatePexQueryByIdOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


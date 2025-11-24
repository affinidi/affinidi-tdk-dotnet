# AffinidiTdk.IotaClient.Api.DcqlQueryApi

All URIs are relative to *https://apse1.api.affinidi.io/ais*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateDcqlQuery**](DcqlQueryApi.md#createdcqlquery) | **POST** /v1/configurations/{configurationId}/dcql-queries |  |
| [**DeleteDcqlQueryById**](DcqlQueryApi.md#deletedcqlquerybyid) | **DELETE** /v1/configurations/{configurationId}/dcql-queries/{queryId} |  |
| [**GetDcqlQueryById**](DcqlQueryApi.md#getdcqlquerybyid) | **GET** /v1/configurations/{configurationId}/dcql-queries/{queryId} |  |
| [**ListDcqlQueries**](DcqlQueryApi.md#listdcqlqueries) | **GET** /v1/configurations/{configurationId}/dcql-queries |  |
| [**UpdateDcqlQueryById**](DcqlQueryApi.md#updatedcqlquerybyid) | **PATCH** /v1/configurations/{configurationId}/dcql-queries/{queryId} |  |

<a id="createdcqlquery"></a>
# **CreateDcqlQuery**
> DcqlQueryDto CreateDcqlQuery (string configurationId, CreateDcqlQueryInput createDcqlQueryInput)



Creates a new DCQL query in the configuration to query data.

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
    public class CreateDcqlQueryExample
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
            var apiInstance = new DcqlQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var createDcqlQueryInput = new CreateDcqlQueryInput(); // CreateDcqlQueryInput | CreateDcqlQuery

            try
            {
                DcqlQueryDto result = apiInstance.CreateDcqlQuery(configurationId, createDcqlQueryInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DcqlQueryApi.CreateDcqlQuery: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateDcqlQueryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<DcqlQueryDto> response = apiInstance.CreateDcqlQueryWithHttpInfo(configurationId, createDcqlQueryInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DcqlQueryApi.CreateDcqlQueryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | ID of the Affinidi Iota Framework configuration. |  |
| **createDcqlQueryInput** | [**CreateDcqlQueryInput**](CreateDcqlQueryInput.md) | CreateDcqlQuery |  |

### Return type

[**DcqlQueryDto**](DcqlQueryDto.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | CreateDcqlQueryOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletedcqlquerybyid"></a>
# **DeleteDcqlQueryById**
> void DeleteDcqlQueryById (string configurationId, string queryId)



Deletes a DCQL query in the configuration by ID.

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
    public class DeleteDcqlQueryByIdExample
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
            var apiInstance = new DcqlQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var queryId = "queryId_example";  // string | The ID of the query.

            try
            {
                apiInstance.DeleteDcqlQueryById(configurationId, queryId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DcqlQueryApi.DeleteDcqlQueryById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteDcqlQueryByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.DeleteDcqlQueryByIdWithHttpInfo(configurationId, queryId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DcqlQueryApi.DeleteDcqlQueryByIdWithHttpInfo: " + e.Message);
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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getdcqlquerybyid"></a>
# **GetDcqlQueryById**
> DcqlQueryDto GetDcqlQueryById (string configurationId, string queryId)



Retrieves a DCQL query in the configuration by ID.

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
    public class GetDcqlQueryByIdExample
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
            var apiInstance = new DcqlQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var queryId = "queryId_example";  // string | The ID of the query.

            try
            {
                DcqlQueryDto result = apiInstance.GetDcqlQueryById(configurationId, queryId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DcqlQueryApi.GetDcqlQueryById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetDcqlQueryByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<DcqlQueryDto> response = apiInstance.GetDcqlQueryByIdWithHttpInfo(configurationId, queryId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DcqlQueryApi.GetDcqlQueryByIdWithHttpInfo: " + e.Message);
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

[**DcqlQueryDto**](DcqlQueryDto.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | GetDcqlQueryByIdOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listdcqlqueries"></a>
# **ListDcqlQueries**
> ListDcqlQueriesOK ListDcqlQueries (string configurationId, int? limit = null, string? exclusiveStartKey = null)



Lists all DCQL queries in the configuration.

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
    public class ListDcqlQueriesExample
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
            var apiInstance = new DcqlQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var limit = 56;  // int? | Maximum number of records to fetch in a list (optional) 
            var exclusiveStartKey = "exclusiveStartKey_example";  // string? | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. (optional) 

            try
            {
                ListDcqlQueriesOK result = apiInstance.ListDcqlQueries(configurationId, limit, exclusiveStartKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DcqlQueryApi.ListDcqlQueries: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListDcqlQueriesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ListDcqlQueriesOK> response = apiInstance.ListDcqlQueriesWithHttpInfo(configurationId, limit, exclusiveStartKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DcqlQueryApi.ListDcqlQueriesWithHttpInfo: " + e.Message);
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

[**ListDcqlQueriesOK**](ListDcqlQueriesOK.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | ListDcqlQueriesOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatedcqlquerybyid"></a>
# **UpdateDcqlQueryById**
> DcqlQueryDto UpdateDcqlQueryById (string configurationId, string queryId, UpdateDcqlQueryInput updateDcqlQueryInput)



Updates the DCQL query in the configuration by ID.

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
    public class UpdateDcqlQueryByIdExample
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
            var apiInstance = new DcqlQueryApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | ID of the Affinidi Iota Framework configuration.
            var queryId = "queryId_example";  // string | The ID of the query.
            var updateDcqlQueryInput = new UpdateDcqlQueryInput(); // UpdateDcqlQueryInput | UpdateDcqlQueryById

            try
            {
                DcqlQueryDto result = apiInstance.UpdateDcqlQueryById(configurationId, queryId, updateDcqlQueryInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DcqlQueryApi.UpdateDcqlQueryById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateDcqlQueryByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<DcqlQueryDto> response = apiInstance.UpdateDcqlQueryByIdWithHttpInfo(configurationId, queryId, updateDcqlQueryInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DcqlQueryApi.UpdateDcqlQueryByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | ID of the Affinidi Iota Framework configuration. |  |
| **queryId** | **string** | The ID of the query. |  |
| **updateDcqlQueryInput** | [**UpdateDcqlQueryInput**](UpdateDcqlQueryInput.md) | UpdateDcqlQueryById |  |

### Return type

[**DcqlQueryDto**](DcqlQueryDto.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | UpdateDcqlQueryByIdOK |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


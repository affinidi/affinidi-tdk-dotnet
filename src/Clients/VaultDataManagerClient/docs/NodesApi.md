# AffinidiTdk.VaultDataManagerClient.Api.NodesApi

All URIs are relative to *https://api.vault.affinidi.com/vfs*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateChildNode**](NodesApi.md#createchildnode) | **POST** /v1/nodes/{nodeId} |  |
| [**CreateNode**](NodesApi.md#createnode) | **POST** /v1/nodes |  |
| [**DeleteNode**](NodesApi.md#deletenode) | **DELETE** /v1/nodes/{nodeId} |  |
| [**GetDetailedNodeInfo**](NodesApi.md#getdetailednodeinfo) | **GET** /v1/nodes/{nodeId} |  |
| [**InitNodes**](NodesApi.md#initnodes) | **POST** /v1/nodes/init |  |
| [**ListNodeChildren**](NodesApi.md#listnodechildren) | **GET** /v1/nodes/{nodeId}/children |  |
| [**ListRootNodeChildren**](NodesApi.md#listrootnodechildren) | **GET** /v1/nodes |  |
| [**MoveNode**](NodesApi.md#movenode) | **POST** /v1/nodes/{nodeId}/move |  |
| [**PermanentlyDeleteNode**](NodesApi.md#permanentlydeletenode) | **DELETE** /v1/nodes/{nodeId}/remove/{nodeIdToRemove} |  |
| [**RestoreNodeFromTrashbin**](NodesApi.md#restorenodefromtrashbin) | **POST** /v1/nodes/{nodeId}/restore/{nodeIdToRestore} |  |
| [**UpdateNode**](NodesApi.md#updatenode) | **PATCH** /v1/nodes/{nodeId} |  |

<a id="createchildnode"></a>
# **CreateChildNode**
> CreateNodeOK CreateChildNode (string nodeId, CreateChildNodeInput createChildNodeInput)



creates child node

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
    public class CreateChildNodeExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | parent node id
            var createChildNodeInput = new CreateChildNodeInput(); // CreateChildNodeInput | CreateChildNode

            try
            {
                CreateNodeOK result = apiInstance.CreateChildNode(nodeId, createChildNodeInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.CreateChildNode: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateChildNodeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<CreateNodeOK> response = apiInstance.CreateChildNodeWithHttpInfo(nodeId, createChildNodeInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.CreateChildNodeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** | parent node id |  |
| **createChildNodeInput** | [**CreateChildNodeInput**](CreateChildNodeInput.md) | CreateChildNode |  |

### Return type

[**CreateNodeOK**](CreateNodeOK.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | CreateNodeOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="createnode"></a>
# **CreateNode**
> CreateNodeOK CreateNode (CreateNodeInput createNodeInput)



create a node

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
    public class CreateNodeExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);
            var createNodeInput = new CreateNodeInput(); // CreateNodeInput | CreateNode

            try
            {
                CreateNodeOK result = apiInstance.CreateNode(createNodeInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.CreateNode: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateNodeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<CreateNodeOK> response = apiInstance.CreateNodeWithHttpInfo(createNodeInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.CreateNodeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createNodeInput** | [**CreateNodeInput**](CreateNodeInput.md) | CreateNode |  |

### Return type

[**CreateNodeOK**](CreateNodeOK.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | CreateNodeOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletenode"></a>
# **DeleteNode**
> DeleteNodeDto DeleteNode (string nodeId)



Mark a node and any attached files for deletion. If the node is a folder, perform the same action for all its children if the profile type is PROFILE, VC_ROOT, or VC. For other node types, move them to the TRASH_BIN node.

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
    public class DeleteNodeExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | 

            try
            {
                DeleteNodeDto result = apiInstance.DeleteNode(nodeId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.DeleteNode: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteNodeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<DeleteNodeDto> response = apiInstance.DeleteNodeWithHttpInfo(nodeId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.DeleteNodeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** |  |  |

### Return type

[**DeleteNodeDto**](DeleteNodeDto.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | DeleteNodeOk |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getdetailednodeinfo"></a>
# **GetDetailedNodeInfo**
> GetDetailedNodeInfoOK GetDetailedNodeInfo (string nodeId, string? dek = null)



Gets detailed information about the node

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
    public class GetDetailedNodeInfoExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | 
            var dek = "dek_example";  // string? | A base64url encoded data encryption key, encrypted using VFS public key. getUrl will not be returned if dek is not provided (optional) 

            try
            {
                GetDetailedNodeInfoOK result = apiInstance.GetDetailedNodeInfo(nodeId, dek);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.GetDetailedNodeInfo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetDetailedNodeInfoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<GetDetailedNodeInfoOK> response = apiInstance.GetDetailedNodeInfoWithHttpInfo(nodeId, dek);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.GetDetailedNodeInfoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** |  |  |
| **dek** | **string?** | A base64url encoded data encryption key, encrypted using VFS public key. getUrl will not be returned if dek is not provided | [optional]  |

### Return type

[**GetDetailedNodeInfoOK**](GetDetailedNodeInfoOK.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | GetDetailedNodeInfoOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="initnodes"></a>
# **InitNodes**
> InitNodesOK InitNodes ()



Initialize root node, and TRASH_BIN

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
    public class InitNodesExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);

            try
            {
                InitNodesOK result = apiInstance.InitNodes();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.InitNodes: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InitNodesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<InitNodesOK> response = apiInstance.InitNodesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.InitNodesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**InitNodesOK**](InitNodesOK.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | InitNodesOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listnodechildren"></a>
# **ListNodeChildren**
> ListNodeChildrenOK ListNodeChildren (string nodeId, int? limit = null, string? exclusiveStartKey = null)



lists children of the node

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
    public class ListNodeChildrenExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | Description for nodeId.
            var limit = 10;  // int? | Maximum number of records to fetch in a list (optional)  (default to 10)
            var exclusiveStartKey = "exclusiveStartKey_example";  // string? | exclusiveStartKey for retrieving the next batch of data. (optional) 

            try
            {
                ListNodeChildrenOK result = apiInstance.ListNodeChildren(nodeId, limit, exclusiveStartKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.ListNodeChildren: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListNodeChildrenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ListNodeChildrenOK> response = apiInstance.ListNodeChildrenWithHttpInfo(nodeId, limit, exclusiveStartKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.ListNodeChildrenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** | Description for nodeId. |  |
| **limit** | **int?** | Maximum number of records to fetch in a list | [optional] [default to 10] |
| **exclusiveStartKey** | **string?** | exclusiveStartKey for retrieving the next batch of data. | [optional]  |

### Return type

[**ListNodeChildrenOK**](ListNodeChildrenOK.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | ListNodeChildrenOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listrootnodechildren"></a>
# **ListRootNodeChildren**
> ListRootNodeChildrenOK ListRootNodeChildren ()



lists children of the root node for the consumer

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
    public class ListRootNodeChildrenExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);

            try
            {
                ListRootNodeChildrenOK result = apiInstance.ListRootNodeChildren();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.ListRootNodeChildren: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListRootNodeChildrenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<ListRootNodeChildrenOK> response = apiInstance.ListRootNodeChildrenWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.ListRootNodeChildrenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ListRootNodeChildrenOK**](ListRootNodeChildrenOK.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | ListRootNodeChildrenOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="movenode"></a>
# **MoveNode**
> MoveNodeDto MoveNode (string nodeId, MoveNodeInput moveNodeInput)



Moves a node from source to destination along with the hierarchy

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
    public class MoveNodeExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | 
            var moveNodeInput = new MoveNodeInput(); // MoveNodeInput | MoveNode

            try
            {
                MoveNodeDto result = apiInstance.MoveNode(nodeId, moveNodeInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.MoveNode: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the MoveNodeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<MoveNodeDto> response = apiInstance.MoveNodeWithHttpInfo(nodeId, moveNodeInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.MoveNodeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** |  |  |
| **moveNodeInput** | [**MoveNodeInput**](MoveNodeInput.md) | MoveNode |  |

### Return type

[**MoveNodeDto**](MoveNodeDto.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | UpdateNodeOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="permanentlydeletenode"></a>
# **PermanentlyDeleteNode**
> void PermanentlyDeleteNode (string nodeId, string nodeIdToRemove)



Permanently delete a node from TRASH_BIN, if the node is not in the TRASH_BIN it cannot delete.

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
    public class PermanentlyDeleteNodeExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | nodeId of the TRASH_BIN
            var nodeIdToRemove = "nodeIdToRemove_example";  // string | nodeId of the node to be deleted from TRASH_BIN

            try
            {
                apiInstance.PermanentlyDeleteNode(nodeId, nodeIdToRemove);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.PermanentlyDeleteNode: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PermanentlyDeleteNodeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.PermanentlyDeleteNodeWithHttpInfo(nodeId, nodeIdToRemove);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.PermanentlyDeleteNodeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** | nodeId of the TRASH_BIN |  |
| **nodeIdToRemove** | **string** | nodeId of the node to be deleted from TRASH_BIN |  |

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
| **202** | Permanently deleted |  -  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="restorenodefromtrashbin"></a>
# **RestoreNodeFromTrashbin**
> MoveNodeDto RestoreNodeFromTrashbin (string nodeId, string nodeIdToRestore, RestoreNodeFromTrashbin restoreNodeFromTrashbin)



Restore node marked for deletion from TRASH_BIN

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
    public class RestoreNodeFromTrashbinExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | nodeId of the TRASH_BIN
            var nodeIdToRestore = "nodeIdToRestore_example";  // string | nodeId of the node to be restored from TRASH_BIN
            var restoreNodeFromTrashbin = new RestoreNodeFromTrashbin(); // RestoreNodeFromTrashbin | RestoreNodeFromTrashbin

            try
            {
                MoveNodeDto result = apiInstance.RestoreNodeFromTrashbin(nodeId, nodeIdToRestore, restoreNodeFromTrashbin);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.RestoreNodeFromTrashbin: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RestoreNodeFromTrashbinWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<MoveNodeDto> response = apiInstance.RestoreNodeFromTrashbinWithHttpInfo(nodeId, nodeIdToRestore, restoreNodeFromTrashbin);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.RestoreNodeFromTrashbinWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** | nodeId of the TRASH_BIN |  |
| **nodeIdToRestore** | **string** | nodeId of the node to be restored from TRASH_BIN |  |
| **restoreNodeFromTrashbin** | [**RestoreNodeFromTrashbin**](RestoreNodeFromTrashbin.md) | RestoreNodeFromTrashbin |  |

### Return type

[**MoveNodeDto**](MoveNodeDto.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | RestoreNodeOk |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatenode"></a>
# **UpdateNode**
> NodeDto UpdateNode (string nodeId, UpdateNodeInput updateNodeInput)



Updates a node

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
    public class UpdateNodeExample
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
            var apiInstance = new NodesApi(httpClient, config, httpClientHandler);
            var nodeId = "nodeId_example";  // string | Description for nodeId.
            var updateNodeInput = new UpdateNodeInput(); // UpdateNodeInput | UpdateNodeInput

            try
            {
                NodeDto result = apiInstance.UpdateNode(nodeId, updateNodeInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NodesApi.UpdateNode: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateNodeWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<NodeDto> response = apiInstance.UpdateNodeWithHttpInfo(nodeId, updateNodeInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NodesApi.UpdateNodeWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nodeId** | **string** | Description for nodeId. |  |
| **updateNodeInput** | [**UpdateNodeInput**](UpdateNodeInput.md) | UpdateNodeInput |  |

### Return type

[**NodeDto**](NodeDto.md)

### Authorization

[ConsumerTokenAuth](../README.md#ConsumerTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | UpdateNodeOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


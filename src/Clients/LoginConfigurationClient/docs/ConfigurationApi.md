# AffinidiTdk.LoginConfigurationClient.Api.ConfigurationApi

All URIs are relative to *https://apse1.api.affinidi.io/vpa*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateLoginConfigurations**](ConfigurationApi.md#createloginconfigurations) | **POST** /v1/login/configurations | Create a new login configuration |
| [**DeleteLoginConfigurationsById**](ConfigurationApi.md#deleteloginconfigurationsbyid) | **DELETE** /v1/login/configurations/{configurationId} | Delete login configurations by ID |
| [**GetClientMetadataByClientId**](ConfigurationApi.md#getclientmetadatabyclientid) | **GET** /v1/login/configurations/metadata/{clientId} | Get Client Metadata By  OAuth 2.0 Client ID |
| [**GetLoginConfigurationsById**](ConfigurationApi.md#getloginconfigurationsbyid) | **GET** /v1/login/configurations/{configurationId} | Get login configuration by ID |
| [**ListLoginConfigurations**](ConfigurationApi.md#listloginconfigurations) | **GET** /v1/login/configurations | List login configurations |
| [**UpdateLoginConfigurationsById**](ConfigurationApi.md#updateloginconfigurationsbyid) | **PATCH** /v1/login/configurations/{configurationId} | Update login configurations by ID |

<a id="createloginconfigurations"></a>
# **CreateLoginConfigurations**
> CreateLoginConfigurationOutput CreateLoginConfigurations (CreateLoginConfigurationInput? createLoginConfigurationInput = null)

Create a new login configuration

Create a new login configuration  `vpDefinition` and `idTokenMapping` have default settings that provide user email VP presentation definitions.  An essential default definition is in place when it comes to the login process for end users using the Chrome extension.  This definition requires users to input their email address as OIDCVP compliant, which is then verified by the Affinidi verification service. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;

namespace Example
{
    public class CreateLoginConfigurationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ConfigurationApi(httpClient, config, httpClientHandler);
            var createLoginConfigurationInput = new CreateLoginConfigurationInput?(); // CreateLoginConfigurationInput? | CreateLoginConfigurations (optional) 

            try
            {
                // Create a new login configuration
                CreateLoginConfigurationOutput result = apiInstance.CreateLoginConfigurations(createLoginConfigurationInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigurationApi.CreateLoginConfigurations: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateLoginConfigurationsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a new login configuration
    ApiResponse<CreateLoginConfigurationOutput> response = apiInstance.CreateLoginConfigurationsWithHttpInfo(createLoginConfigurationInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigurationApi.CreateLoginConfigurationsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createLoginConfigurationInput** | [**CreateLoginConfigurationInput?**](CreateLoginConfigurationInput?.md) | CreateLoginConfigurations | [optional]  |

### Return type

[**CreateLoginConfigurationOutput**](CreateLoginConfigurationOutput.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |
| **424** | FailedDependencyError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deleteloginconfigurationsbyid"></a>
# **DeleteLoginConfigurationsById**
> void DeleteLoginConfigurationsById (string configurationId)

Delete login configurations by ID

Delete login configurations by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;

namespace Example
{
    public class DeleteLoginConfigurationsByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ConfigurationApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | The id of the login configuration

            try
            {
                // Delete login configurations by ID
                apiInstance.DeleteLoginConfigurationsById(configurationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigurationApi.DeleteLoginConfigurationsById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteLoginConfigurationsByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete login configurations by ID
    apiInstance.DeleteLoginConfigurationsByIdWithHttpInfo(configurationId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigurationApi.DeleteLoginConfigurationsByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | The id of the login configuration |  |

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

<a id="getclientmetadatabyclientid"></a>
# **GetClientMetadataByClientId**
> LoginConfigurationClientMetadataOutput GetClientMetadataByClientId (string clientId)

Get Client Metadata By  OAuth 2.0 Client ID

Get Client Metadata By  OAuth 2.0 Client ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;

namespace Example
{
    public class GetClientMetadataByClientIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ConfigurationApi(httpClient, config, httpClientHandler);
            var clientId = "clientId_example";  // string | OAuth 2.0 Client ID

            try
            {
                // Get Client Metadata By  OAuth 2.0 Client ID
                LoginConfigurationClientMetadataOutput result = apiInstance.GetClientMetadataByClientId(clientId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigurationApi.GetClientMetadataByClientId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetClientMetadataByClientIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Client Metadata By  OAuth 2.0 Client ID
    ApiResponse<LoginConfigurationClientMetadataOutput> response = apiInstance.GetClientMetadataByClientIdWithHttpInfo(clientId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigurationApi.GetClientMetadataByClientIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **clientId** | **string** | OAuth 2.0 Client ID |  |

### Return type

[**LoginConfigurationClientMetadataOutput**](LoginConfigurationClientMetadataOutput.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | BadRequestError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getloginconfigurationsbyid"></a>
# **GetLoginConfigurationsById**
> LoginConfigurationObject GetLoginConfigurationsById (string configurationId)

Get login configuration by ID

Get login configuration by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;

namespace Example
{
    public class GetLoginConfigurationsByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ConfigurationApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | The id of the login configuration

            try
            {
                // Get login configuration by ID
                LoginConfigurationObject result = apiInstance.GetLoginConfigurationsById(configurationId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigurationApi.GetLoginConfigurationsById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetLoginConfigurationsByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get login configuration by ID
    ApiResponse<LoginConfigurationObject> response = apiInstance.GetLoginConfigurationsByIdWithHttpInfo(configurationId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigurationApi.GetLoginConfigurationsByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | The id of the login configuration |  |

### Return type

[**LoginConfigurationObject**](LoginConfigurationObject.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | GetLoginConfigurationOutput |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listloginconfigurations"></a>
# **ListLoginConfigurations**
> ListLoginConfigurationOutput ListLoginConfigurations (int? limit = null, string? exclusiveStartKey = null)

List login configurations

Endpoint to retrieve list of login configurations

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;

namespace Example
{
    public class ListLoginConfigurationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ConfigurationApi(httpClient, config, httpClientHandler);
            var limit = 56;  // int? | Maximum number of records to fetch in a list (optional) 
            var exclusiveStartKey = "exclusiveStartKey_example";  // string? | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. (optional) 

            try
            {
                // List login configurations
                ListLoginConfigurationOutput result = apiInstance.ListLoginConfigurations(limit, exclusiveStartKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigurationApi.ListLoginConfigurations: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListLoginConfigurationsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List login configurations
    ApiResponse<ListLoginConfigurationOutput> response = apiInstance.ListLoginConfigurationsWithHttpInfo(limit, exclusiveStartKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigurationApi.ListLoginConfigurationsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **limit** | **int?** | Maximum number of records to fetch in a list | [optional]  |
| **exclusiveStartKey** | **string?** | The base64url encoded key of the first item that this operation will evaluate (it is not returned). Use the value that was returned in the previous operation. | [optional]  |

### Return type

[**ListLoginConfigurationOutput**](ListLoginConfigurationOutput.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | ListLoginConfigurationOutput |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateloginconfigurationsbyid"></a>
# **UpdateLoginConfigurationsById**
> LoginConfigurationObject UpdateLoginConfigurationsById (string configurationId, UpdateLoginConfigurationInput? updateLoginConfigurationInput = null)

Update login configurations by ID

Update login configurations by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.LoginConfigurationClient.Api;
using AffinidiTdk.LoginConfigurationClient.Client;
using AffinidiTdk.LoginConfigurationClient.Model;

namespace Example
{
    public class UpdateLoginConfigurationsByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new ConfigurationApi(httpClient, config, httpClientHandler);
            var configurationId = "configurationId_example";  // string | The id of the login configuration
            var updateLoginConfigurationInput = new UpdateLoginConfigurationInput?(); // UpdateLoginConfigurationInput? | UpdateLoginConfigurationsById (optional) 

            try
            {
                // Update login configurations by ID
                LoginConfigurationObject result = apiInstance.UpdateLoginConfigurationsById(configurationId, updateLoginConfigurationInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigurationApi.UpdateLoginConfigurationsById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateLoginConfigurationsByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update login configurations by ID
    ApiResponse<LoginConfigurationObject> response = apiInstance.UpdateLoginConfigurationsByIdWithHttpInfo(configurationId, updateLoginConfigurationInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigurationApi.UpdateLoginConfigurationsByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **configurationId** | **string** | The id of the login configuration |  |
| **updateLoginConfigurationInput** | [**UpdateLoginConfigurationInput?**](UpdateLoginConfigurationInput?.md) | UpdateLoginConfigurationsById | [optional]  |

### Return type

[**LoginConfigurationObject**](LoginConfigurationObject.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | UpdateLoginConfigurationOutput |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


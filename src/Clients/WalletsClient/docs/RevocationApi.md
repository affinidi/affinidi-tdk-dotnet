# AffinidiTdk.WalletsClient.Api.RevocationApi

All URIs are relative to *https://apse1.api.affinidi.io/cwe*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetRevocationCredentialStatus**](RevocationApi.md#getrevocationcredentialstatus) | **GET** /v1/projects/{projectId}/wallets/{walletId}/revocation-statuses/{statusId} |  |
| [**GetRevocationListCredential**](RevocationApi.md#getrevocationlistcredential) | **GET** /v1/wallets/{walletId}/revocation-list/{listId} | Return revocation list credential. |
| [**RevokeCredential**](RevocationApi.md#revokecredential) | **POST** /v1/wallets/{walletId}/revoke | Revoke Credential. |
| [**RevokeCredentials**](RevocationApi.md#revokecredentials) | **POST** /v2/wallets/{walletId}/credentials/revoke | Revoke Credentials. |

<a id="getrevocationcredentialstatus"></a>
# **GetRevocationCredentialStatus**
> GetRevocationListCredentialResultDto GetRevocationCredentialStatus (string projectId, string walletId, string statusId)



Get revocation status list as RevocationListCredential

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;

namespace Example
{
    public class GetRevocationCredentialStatusExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cwe";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new RevocationApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | Description for projectId.
            var walletId = "walletId_example";  // string | Description for walletId.
            var statusId = "statusId_example";  // string | Description for statusId.

            try
            {
                GetRevocationListCredentialResultDto result = apiInstance.GetRevocationCredentialStatus(projectId, walletId, statusId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RevocationApi.GetRevocationCredentialStatus: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetRevocationCredentialStatusWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<GetRevocationListCredentialResultDto> response = apiInstance.GetRevocationCredentialStatusWithHttpInfo(projectId, walletId, statusId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RevocationApi.GetRevocationCredentialStatusWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** | Description for projectId. |  |
| **walletId** | **string** | Description for walletId. |  |
| **statusId** | **string** | Description for statusId. |  |

### Return type

[**GetRevocationListCredentialResultDto**](GetRevocationListCredentialResultDto.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | GetRevocationCredentialStatusOK |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getrevocationlistcredential"></a>
# **GetRevocationListCredential**
> GetRevocationListCredentialResultDto GetRevocationListCredential (string listId, string walletId)

Return revocation list credential.

Get revocation list 2020 Credential (required to check if VC revoked). It is a public endpoint.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;

namespace Example
{
    public class GetRevocationListCredentialExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cwe";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new RevocationApi(httpClient, config, httpClientHandler);
            var listId = "listId_example";  // string | 
            var walletId = "walletId_example";  // string | id of the wallet

            try
            {
                // Return revocation list credential.
                GetRevocationListCredentialResultDto result = apiInstance.GetRevocationListCredential(listId, walletId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RevocationApi.GetRevocationListCredential: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetRevocationListCredentialWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Return revocation list credential.
    ApiResponse<GetRevocationListCredentialResultDto> response = apiInstance.GetRevocationListCredentialWithHttpInfo(listId, walletId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RevocationApi.GetRevocationListCredentialWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **listId** | **string** |  |  |
| **walletId** | **string** | id of the wallet |  |

### Return type

[**GetRevocationListCredentialResultDto**](GetRevocationListCredentialResultDto.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="revokecredential"></a>
# **RevokeCredential**
> void RevokeCredential (string walletId, RevokeCredentialInput revokeCredentialInput)

Revoke Credential.

Update index/credetial at appropriate revocation list (set revoken is true).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;

namespace Example
{
    public class RevokeCredentialExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cwe";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new RevocationApi(httpClient, config, httpClientHandler);
            var walletId = "walletId_example";  // string | id of the wallet
            var revokeCredentialInput = new RevokeCredentialInput(); // RevokeCredentialInput | RevokeCredential

            try
            {
                // Revoke Credential.
                apiInstance.RevokeCredential(walletId, revokeCredentialInput);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RevocationApi.RevokeCredential: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RevokeCredentialWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Revoke Credential.
    apiInstance.RevokeCredentialWithHttpInfo(walletId, revokeCredentialInput);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RevocationApi.RevokeCredentialWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **walletId** | **string** | id of the wallet |  |
| **revokeCredentialInput** | [**RevokeCredentialInput**](RevokeCredentialInput.md) | RevokeCredential |  |

### Return type

void (empty response body)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **400** | BadRequestError |  -  |
| **403** | ForbiddenError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="revokecredentials"></a>
# **RevokeCredentials**
> void RevokeCredentials (string walletId, RevokeCredentialsInput revokeCredentialsInput)

Revoke Credentials.

Update index/credential at appropriate revocation list (set revoked is true).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.WalletsClient.Api;
using AffinidiTdk.WalletsClient.Client;
using AffinidiTdk.WalletsClient.Model;

namespace Example
{
    public class RevokeCredentialsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cwe";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new RevocationApi(httpClient, config, httpClientHandler);
            var walletId = "walletId_example";  // string | id of the wallet
            var revokeCredentialsInput = new RevokeCredentialsInput(); // RevokeCredentialsInput | RevokeCredentials

            try
            {
                // Revoke Credentials.
                apiInstance.RevokeCredentials(walletId, revokeCredentialsInput);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RevocationApi.RevokeCredentials: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RevokeCredentialsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Revoke Credentials.
    apiInstance.RevokeCredentialsWithHttpInfo(walletId, revokeCredentialsInput);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RevocationApi.RevokeCredentialsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **walletId** | **string** | id of the wallet |  |
| **revokeCredentialsInput** | [**RevokeCredentialsInput**](RevokeCredentialsInput.md) | RevokeCredentials |  |

### Return type

void (empty response body)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **400** | BadRequestError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


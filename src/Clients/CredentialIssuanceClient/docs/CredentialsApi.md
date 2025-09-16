# AffinidiTdk.CredentialIssuanceClient.Api.CredentialsApi

All URIs are relative to *https://apse1.api.affinidi.io/cis*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**BatchCredential**](CredentialsApi.md#batchcredential) | **POST** /v1/{projectId}/batch_credential | Allows wallets to claim multiple credentials at once. |
| [**GenerateCredentials**](CredentialsApi.md#generatecredentials) | **POST** /v1/{projectId}/credential |  |
| [**GetClaimedCredentials**](CredentialsApi.md#getclaimedcredentials) | **GET** /v1/{projectId}/configurations/{configurationId}/credentials | Get claimed credential in the specified range |
| [**GetIssuanceIdClaimedCredential**](CredentialsApi.md#getissuanceidclaimedcredential) | **GET** /v1/{projectId}/configurations/{configurationId}/issuances/{issuanceId}/credentials | Get claimed VC linked to the issuanceId |

<a id="batchcredential"></a>
# **BatchCredential**
> BatchCredentialResponse BatchCredential (string projectId, BatchCredentialInput batchCredentialInput)

Allows wallets to claim multiple credentials at once.

Allows wallets to claim multiple credentials at once. For authentication, it uses a token from the authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.CredentialIssuanceClient.Api;
using AffinidiTdk.CredentialIssuanceClient.Client;
using AffinidiTdk.CredentialIssuanceClient.Model;

namespace Example
{
    public class BatchCredentialExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cis";
            // Configure Bearer token for authorization: bearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new CredentialsApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | Affinidi project id
            var batchCredentialInput = new BatchCredentialInput(); // BatchCredentialInput | Request body for batch credential

            try
            {
                // Allows wallets to claim multiple credentials at once.
                BatchCredentialResponse result = apiInstance.BatchCredential(projectId, batchCredentialInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CredentialsApi.BatchCredential: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the BatchCredentialWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Allows wallets to claim multiple credentials at once.
    ApiResponse<BatchCredentialResponse> response = apiInstance.BatchCredentialWithHttpInfo(projectId, batchCredentialInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CredentialsApi.BatchCredentialWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** | Affinidi project id |  |
| **batchCredentialInput** | [**BatchCredentialInput**](BatchCredentialInput.md) | Request body for batch credential |  |

### Return type

[**BatchCredentialResponse**](BatchCredentialResponse.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="generatecredentials"></a>
# **GenerateCredentials**
> CredentialResponse GenerateCredentials (string projectId, CreateCredentialInput createCredentialInput)



Issue credential for end user upon presentation a valid access token. Since we don't immediate issue credential It's expected to return `transaction_id` and use this `transaction_id` to get the deferred credentials

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.CredentialIssuanceClient.Api;
using AffinidiTdk.CredentialIssuanceClient.Client;
using AffinidiTdk.CredentialIssuanceClient.Model;

namespace Example
{
    public class GenerateCredentialsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cis";
            // Configure Bearer token for authorization: bearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new CredentialsApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | Affinidi project id
            var createCredentialInput = new CreateCredentialInput(); // CreateCredentialInput | Request body to issue credentials

            try
            {
                CredentialResponse result = apiInstance.GenerateCredentials(projectId, createCredentialInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CredentialsApi.GenerateCredentials: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GenerateCredentialsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<CredentialResponse> response = apiInstance.GenerateCredentialsWithHttpInfo(projectId, createCredentialInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CredentialsApi.GenerateCredentialsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** | Affinidi project id |  |
| **createCredentialInput** | [**CreateCredentialInput**](CreateCredentialInput.md) | Request body to issue credentials |  |

### Return type

[**CredentialResponse**](CredentialResponse.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **401** | UnauthorizedError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getclaimedcredentials"></a>
# **GetClaimedCredentials**
> ClaimedCredentialListResponse GetClaimedCredentials (string projectId, string configurationId, string rangeStartTime, string? rangeEndTime = null, string? exclusiveStartKey = null, int? limit = null)

Get claimed credential in the specified range

Get claimed credential in the specified range

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.CredentialIssuanceClient.Api;
using AffinidiTdk.CredentialIssuanceClient.Client;
using AffinidiTdk.CredentialIssuanceClient.Model;

namespace Example
{
    public class GetClaimedCredentialsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cis";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new CredentialsApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | project id
            var configurationId = "configurationId_example";  // string | configuration id
            var rangeStartTime = "rangeStartTime_example";  // string | 
            var rangeEndTime = "rangeEndTime_example";  // string? |  (optional) 
            var exclusiveStartKey = "exclusiveStartKey_example";  // string? | exclusiveStartKey for retrieving the next batch of data. (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // Get claimed credential in the specified range
                ClaimedCredentialListResponse result = apiInstance.GetClaimedCredentials(projectId, configurationId, rangeStartTime, rangeEndTime, exclusiveStartKey, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CredentialsApi.GetClaimedCredentials: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetClaimedCredentialsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get claimed credential in the specified range
    ApiResponse<ClaimedCredentialListResponse> response = apiInstance.GetClaimedCredentialsWithHttpInfo(projectId, configurationId, rangeStartTime, rangeEndTime, exclusiveStartKey, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CredentialsApi.GetClaimedCredentialsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** | project id |  |
| **configurationId** | **string** | configuration id |  |
| **rangeStartTime** | **string** |  |  |
| **rangeEndTime** | **string?** |  | [optional]  |
| **exclusiveStartKey** | **string?** | exclusiveStartKey for retrieving the next batch of data. | [optional]  |
| **limit** | **int?** |  | [optional] [default to 20] |

### Return type

[**ClaimedCredentialListResponse**](ClaimedCredentialListResponse.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **404** | NotFoundError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getissuanceidclaimedcredential"></a>
# **GetIssuanceIdClaimedCredential**
> ClaimedCredentialResponse GetIssuanceIdClaimedCredential (string projectId, string configurationId, string issuanceId)

Get claimed VC linked to the issuanceId

Get claimed VC linked to the issuanceId

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using AffinidiTdk.CredentialIssuanceClient.Api;
using AffinidiTdk.CredentialIssuanceClient.Client;
using AffinidiTdk.CredentialIssuanceClient.Model;

namespace Example
{
    public class GetIssuanceIdClaimedCredentialExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/cis";
            // Configure API key authorization: ProjectTokenAuth
            config.AddApiKey("authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("authorization", "Bearer");

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new CredentialsApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | project id
            var configurationId = "configurationId_example";  // string | configuration id
            var issuanceId = "issuanceId_example";  // string | issuance id

            try
            {
                // Get claimed VC linked to the issuanceId
                ClaimedCredentialResponse result = apiInstance.GetIssuanceIdClaimedCredential(projectId, configurationId, issuanceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CredentialsApi.GetIssuanceIdClaimedCredential: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetIssuanceIdClaimedCredentialWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get claimed VC linked to the issuanceId
    ApiResponse<ClaimedCredentialResponse> response = apiInstance.GetIssuanceIdClaimedCredentialWithHttpInfo(projectId, configurationId, issuanceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CredentialsApi.GetIssuanceIdClaimedCredentialWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** | project id |  |
| **configurationId** | **string** | configuration id |  |
| **issuanceId** | **string** | issuance id |  |

### Return type

[**ClaimedCredentialResponse**](ClaimedCredentialResponse.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **404** | NotFoundError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


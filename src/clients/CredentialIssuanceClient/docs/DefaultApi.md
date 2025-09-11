# AffinidiTdk.CredentialIssuanceClient.Api.DefaultApi

All URIs are relative to *https://apse1.api.affinidi.io/cis*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ChangeCredentialStatus**](DefaultApi.md#changecredentialstatus) | **POST** /v1/{projectId}/configurations/{configurationId}/issuance/change-status | change credential status. |
| [**ListIssuanceDataRecords**](DefaultApi.md#listissuancedatarecords) | **GET** /v1/{projectId}/configurations/{configurationId}/issuance/issuance-data-records | List records |

<a id="changecredentialstatus"></a>
# **ChangeCredentialStatus**
> FlowData ChangeCredentialStatus (string projectId, string configurationId, ChangeCredentialStatusInput changeCredentialStatusInput)

change credential status.

change credential status.

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
    public class ChangeCredentialStatusExample
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
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | project id
            var configurationId = "configurationId_example";  // string | configuration id
            var changeCredentialStatusInput = new ChangeCredentialStatusInput(); // ChangeCredentialStatusInput | Request body for changing credential status

            try
            {
                // change credential status.
                FlowData result = apiInstance.ChangeCredentialStatus(projectId, configurationId, changeCredentialStatusInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.ChangeCredentialStatus: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ChangeCredentialStatusWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // change credential status.
    ApiResponse<FlowData> response = apiInstance.ChangeCredentialStatusWithHttpInfo(projectId, configurationId, changeCredentialStatusInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.ChangeCredentialStatusWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** | project id |  |
| **configurationId** | **string** | configuration id |  |
| **changeCredentialStatusInput** | [**ChangeCredentialStatusInput**](ChangeCredentialStatusInput.md) | Request body for changing credential status |  |

### Return type

[**FlowData**](FlowData.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | updated credential entity |  -  |
| **400** | BadRequestError |  -  |
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listissuancedatarecords"></a>
# **ListIssuanceDataRecords**
> ListIssuanceRecordResponse ListIssuanceDataRecords (string projectId, string configurationId, int? limit = null, string? exclusiveStartKey = null)

List records

Retrieve a list of issuance data records.

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
    public class ListIssuanceDataRecordsExample
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
            var apiInstance = new DefaultApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | Affinidi project id
            var configurationId = "configurationId_example";  // string | The id of the issuance configuration
            var limit = 10;  // int? | Maximum number of records to fetch in a list (optional)  (default to 10)
            var exclusiveStartKey = "exclusiveStartKey_example";  // string? | exclusiveStartKey for retrieving the next batch of data. (optional) 

            try
            {
                // List records
                ListIssuanceRecordResponse result = apiInstance.ListIssuanceDataRecords(projectId, configurationId, limit, exclusiveStartKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.ListIssuanceDataRecords: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListIssuanceDataRecordsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List records
    ApiResponse<ListIssuanceRecordResponse> response = apiInstance.ListIssuanceDataRecordsWithHttpInfo(projectId, configurationId, limit, exclusiveStartKey);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.ListIssuanceDataRecordsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** | Affinidi project id |  |
| **configurationId** | **string** | The id of the issuance configuration |  |
| **limit** | **int?** | Maximum number of records to fetch in a list | [optional] [default to 10] |
| **exclusiveStartKey** | **string?** | exclusiveStartKey for retrieving the next batch of data. | [optional]  |

### Return type

[**ListIssuanceRecordResponse**](ListIssuanceRecordResponse.md)

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
| **404** | NotFoundError |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


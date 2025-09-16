# AffinidiTdk.IotaClient.Api.IotaApi

All URIs are relative to *https://apse1.api.affinidi.io/ais*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AwsExchangeCredentials**](IotaApi.md#awsexchangecredentials) | **POST** /v1/aws-exchange-credentials |  |
| [**AwsExchangeCredentialsProjectToken**](IotaApi.md#awsexchangecredentialsprojecttoken) | **POST** /v1/aws-exchange-credentials/project-token |  |
| [**FetchIotaVpResponse**](IotaApi.md#fetchiotavpresponse) | **POST** /v1/fetch-iota-response |  |
| [**InitiateDataSharingRequest**](IotaApi.md#initiatedatasharingrequest) | **POST** /v1/initiate-data-sharing-request |  |
| [**IotaExchangeCredentials**](IotaApi.md#iotaexchangecredentials) | **POST** /v1/exchange-credentials |  |

<a id="awsexchangecredentials"></a>
# **AwsExchangeCredentials**
> AwsExchangeCredentialsOK AwsExchangeCredentials (AwsExchangeCredentials awsExchangeCredentials)



Exchange a limited-scoped token into a Cognito credential to generate the identity credential. The identity credential initiates the secure WebSocket connection from the client. This method is used only in WebSocket data-sharing mode.

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
    public class AwsExchangeCredentialsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/ais";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IotaApi(httpClient, config, httpClientHandler);
            var awsExchangeCredentials = new AwsExchangeCredentials(); // AwsExchangeCredentials | AwsExchangeCredentials

            try
            {
                AwsExchangeCredentialsOK result = apiInstance.AwsExchangeCredentials(awsExchangeCredentials);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IotaApi.AwsExchangeCredentials: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AwsExchangeCredentialsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AwsExchangeCredentialsOK> response = apiInstance.AwsExchangeCredentialsWithHttpInfo(awsExchangeCredentials);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IotaApi.AwsExchangeCredentialsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **awsExchangeCredentials** | [**AwsExchangeCredentials**](AwsExchangeCredentials.md) | AwsExchangeCredentials |  |

### Return type

[**AwsExchangeCredentialsOK**](AwsExchangeCredentialsOK.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | AwsExchangeCredentialsOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **403** | ForbiddenError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="awsexchangecredentialsprojecttoken"></a>
# **AwsExchangeCredentialsProjectToken**
> IotaExchangeCredentialsOK AwsExchangeCredentialsProjectToken (AwsExchangeCredentialsProjectToken awsExchangeCredentialsProjectToken)



Exchange a Project Scoped Token into an identity credential directly to initiate a secure WebSocket connection. This method is used only in WebSocket data-sharing mode.

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
    public class AwsExchangeCredentialsProjectTokenExample
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
            var apiInstance = new IotaApi(httpClient, config, httpClientHandler);
            var awsExchangeCredentialsProjectToken = new AwsExchangeCredentialsProjectToken(); // AwsExchangeCredentialsProjectToken | AwsExchangeCredentialsProjectToken

            try
            {
                IotaExchangeCredentialsOK result = apiInstance.AwsExchangeCredentialsProjectToken(awsExchangeCredentialsProjectToken);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IotaApi.AwsExchangeCredentialsProjectToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AwsExchangeCredentialsProjectTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<IotaExchangeCredentialsOK> response = apiInstance.AwsExchangeCredentialsProjectTokenWithHttpInfo(awsExchangeCredentialsProjectToken);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IotaApi.AwsExchangeCredentialsProjectTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **awsExchangeCredentialsProjectToken** | [**AwsExchangeCredentialsProjectToken**](AwsExchangeCredentialsProjectToken.md) | AwsExchangeCredentialsProjectToken |  |

### Return type

[**IotaExchangeCredentialsOK**](IotaExchangeCredentialsOK.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | IotaExchangeCredentialsOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **403** | ForbiddenError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="fetchiotavpresponse"></a>
# **FetchIotaVpResponse**
> FetchIOTAVPResponseOK FetchIotaVpResponse (FetchIOTAVPResponseInput fetchIOTAVPResponseInput)



Fetches the client's callback that contains the user's shared data in a Verifiable Presentation format after a successful data-sharing flow.

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
    public class FetchIotaVpResponseExample
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
            var apiInstance = new IotaApi(httpClient, config, httpClientHandler);
            var fetchIOTAVPResponseInput = new FetchIOTAVPResponseInput(); // FetchIOTAVPResponseInput | FetchIOTAVPResponseInput

            try
            {
                FetchIOTAVPResponseOK result = apiInstance.FetchIotaVpResponse(fetchIOTAVPResponseInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IotaApi.FetchIotaVpResponse: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FetchIotaVpResponseWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<FetchIOTAVPResponseOK> response = apiInstance.FetchIotaVpResponseWithHttpInfo(fetchIOTAVPResponseInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IotaApi.FetchIotaVpResponseWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fetchIOTAVPResponseInput** | [**FetchIOTAVPResponseInput**](FetchIOTAVPResponseInput.md) | FetchIOTAVPResponseInput |  |

### Return type

[**FetchIOTAVPResponseOK**](FetchIOTAVPResponseOK.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | FetchIOTAVPResponseOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **403** | ForbiddenError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **404** | NotFoundError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="initiatedatasharingrequest"></a>
# **InitiateDataSharingRequest**
> InitiateDataSharingRequestOK InitiateDataSharingRequest (InitiateDataSharingRequestInput initiateDataSharingRequestInput)



Generates the request token for the Redirect mode to initiate the data-sharing flow.

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
    public class InitiateDataSharingRequestExample
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
            var apiInstance = new IotaApi(httpClient, config, httpClientHandler);
            var initiateDataSharingRequestInput = new InitiateDataSharingRequestInput(); // InitiateDataSharingRequestInput | InitiateDataSharingRequestInput

            try
            {
                InitiateDataSharingRequestOK result = apiInstance.InitiateDataSharingRequest(initiateDataSharingRequestInput);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IotaApi.InitiateDataSharingRequest: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InitiateDataSharingRequestWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<InitiateDataSharingRequestOK> response = apiInstance.InitiateDataSharingRequestWithHttpInfo(initiateDataSharingRequestInput);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IotaApi.InitiateDataSharingRequestWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **initiateDataSharingRequestInput** | [**InitiateDataSharingRequestInput**](InitiateDataSharingRequestInput.md) | InitiateDataSharingRequestInput |  |

### Return type

[**InitiateDataSharingRequestOK**](InitiateDataSharingRequestOK.md)

### Authorization

[ProjectTokenAuth](../README.md#ProjectTokenAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | InitiateDataSharingRequestOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **403** | ForbiddenError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="iotaexchangecredentials"></a>
# **IotaExchangeCredentials**
> IotaExchangeCredentialsOK IotaExchangeCredentials (IotaExchangeCredentials iotaExchangeCredentials)



Exchange a limited-scoped token into an identity credential directly to initiate a secure WebSocket connection. This method is used only in WebSocket data-sharing mode.

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
    public class IotaExchangeCredentialsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/ais";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IotaApi(httpClient, config, httpClientHandler);
            var iotaExchangeCredentials = new IotaExchangeCredentials(); // IotaExchangeCredentials | IotaAwsExchangeCredentials

            try
            {
                IotaExchangeCredentialsOK result = apiInstance.IotaExchangeCredentials(iotaExchangeCredentials);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IotaApi.IotaExchangeCredentials: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the IotaExchangeCredentialsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<IotaExchangeCredentialsOK> response = apiInstance.IotaExchangeCredentialsWithHttpInfo(iotaExchangeCredentials);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IotaApi.IotaExchangeCredentialsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **iotaExchangeCredentials** | [**IotaExchangeCredentials**](IotaExchangeCredentials.md) | IotaAwsExchangeCredentials |  |

### Return type

[**IotaExchangeCredentialsOK**](IotaExchangeCredentialsOK.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | IotaExchangeCredentialsOK |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **400** | BadRequestError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |
| **403** | ForbiddenError |  * Access-Control-Allow-Origin -  <br>  * Access-Control-Allow-Methods -  <br>  * Access-Control-Allow-Headers -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


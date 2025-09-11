# AffinidiTdk.LoginConfigurationClient.Api.IdpApi

All URIs are relative to *https://apse1.api.affinidi.io/vpa*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**V1LoginProjectProjectIdOauth2AuthGet**](IdpApi.md#v1loginprojectprojectidoauth2authget) | **GET** /v1/login/project/{projectId}/oauth2/auth | OAuth 2.0 Authorize Endpoint |
| [**V1LoginProjectProjectIdOauth2RevokePost**](IdpApi.md#v1loginprojectprojectidoauth2revokepost) | **POST** /v1/login/project/{projectId}/oauth2/revoke | Revoke OAuth 2.0 Access or Refresh Token |
| [**V1LoginProjectProjectIdOauth2SessionsLogoutGet**](IdpApi.md#v1loginprojectprojectidoauth2sessionslogoutget) | **GET** /v1/login/project/{projectId}/oauth2/sessions/logout | OpenID Connect Front- and Back-channel Enabled Logout |
| [**V1LoginProjectProjectIdOauth2TokenPost**](IdpApi.md#v1loginprojectprojectidoauth2tokenpost) | **POST** /v1/login/project/{projectId}/oauth2/token | The OAuth 2.0 Token Endpoint |
| [**V1LoginProjectProjectIdUserinfoGet**](IdpApi.md#v1loginprojectprojectiduserinfoget) | **GET** /v1/login/project/{projectId}/userinfo | OpenID Connect Userinfo |
| [**V1LoginProjectProjectIdWellKnownJwksJsonGet**](IdpApi.md#v1loginprojectprojectidwellknownjwksjsonget) | **GET** /v1/login/project/{projectId}/.well-known/jwks.json | Discover Well-Known JSON Web Keys |
| [**V1LoginProjectProjectIdWellKnownOpenidConfigurationGet**](IdpApi.md#v1loginprojectprojectidwellknownopenidconfigurationget) | **GET** /v1/login/project/{projectId}/.well-known/openid-configuration | OpenID Connect Discovery |

<a id="v1loginprojectprojectidoauth2authget"></a>
# **V1LoginProjectProjectIdOauth2AuthGet**
> void V1LoginProjectProjectIdOauth2AuthGet (string projectId)

OAuth 2.0 Authorize Endpoint

The authorization endpoint is one of the components in the OAuth 2.0 flow. It's the URL where a user is redirected to grant or deny access to their resources. When a user tries to access a service that requires OAuth 2.0 authorization, the application will redirect the user to this authorization endpoint. Here, the user can log in (if necessary) and then decide whether to grant the application access. 

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
    public class V1LoginProjectProjectIdOauth2AuthGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IdpApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 

            try
            {
                // OAuth 2.0 Authorize Endpoint
                apiInstance.V1LoginProjectProjectIdOauth2AuthGet(projectId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdOauth2AuthGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V1LoginProjectProjectIdOauth2AuthGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // OAuth 2.0 Authorize Endpoint
    apiInstance.V1LoginProjectProjectIdOauth2AuthGetWithHttpInfo(projectId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdOauth2AuthGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v1loginprojectprojectidoauth2revokepost"></a>
# **V1LoginProjectProjectIdOauth2RevokePost**
> void V1LoginProjectProjectIdOauth2RevokePost (string projectId)

Revoke OAuth 2.0 Access or Refresh Token

Revoking a token (both access and refresh) means that the tokens will be invalid.  A revoked access token can no longer be used to make access requests, and a revoked  refresh token can no longer be used to refresh an access token. Revoking a refresh  token also invalidates the access token that was created with it. A token may only  be revoked by the client the token was generated for. 

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
    public class V1LoginProjectProjectIdOauth2RevokePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IdpApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 

            try
            {
                // Revoke OAuth 2.0 Access or Refresh Token
                apiInstance.V1LoginProjectProjectIdOauth2RevokePost(projectId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdOauth2RevokePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V1LoginProjectProjectIdOauth2RevokePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Revoke OAuth 2.0 Access or Refresh Token
    apiInstance.V1LoginProjectProjectIdOauth2RevokePostWithHttpInfo(projectId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdOauth2RevokePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v1loginprojectprojectidoauth2sessionslogoutget"></a>
# **V1LoginProjectProjectIdOauth2SessionsLogoutGet**
> void V1LoginProjectProjectIdOauth2SessionsLogoutGet (string projectId)

OpenID Connect Front- and Back-channel Enabled Logout

This endpoint initiates and completes user logout at the IdP OAuth2 & OpenID provider and initiates OpenID Connect Front- / Back-channel logout: https://openid.net/specs/openid-connect-frontchannel-1_0.html https://openid.net/specs/openid-connect-backchannel-1_0.html Back-channel logout is performed asynchronously and does not affect logout flow. 

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
    public class V1LoginProjectProjectIdOauth2SessionsLogoutGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IdpApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 

            try
            {
                // OpenID Connect Front- and Back-channel Enabled Logout
                apiInstance.V1LoginProjectProjectIdOauth2SessionsLogoutGet(projectId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdOauth2SessionsLogoutGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V1LoginProjectProjectIdOauth2SessionsLogoutGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // OpenID Connect Front- and Back-channel Enabled Logout
    apiInstance.V1LoginProjectProjectIdOauth2SessionsLogoutGetWithHttpInfo(projectId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdOauth2SessionsLogoutGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v1loginprojectprojectidoauth2tokenpost"></a>
# **V1LoginProjectProjectIdOauth2TokenPost**
> OAuth2Token V1LoginProjectProjectIdOauth2TokenPost (string projectId)

The OAuth 2.0 Token Endpoint

The token endpoint is a critical component in the OAuth 2.0 protocol. It's the URL where a client application makes a request to exchange an authorization grant (such as an authorization code) for an access token. After a user grants authorization at the authorization endpoint, the client application receives an authorization grant, which is then exchanged for an access token at the token endpoint. This access token is then used to access the user's resources on the protected server. 

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
    public class V1LoginProjectProjectIdOauth2TokenPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IdpApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 

            try
            {
                // The OAuth 2.0 Token Endpoint
                OAuth2Token result = apiInstance.V1LoginProjectProjectIdOauth2TokenPost(projectId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdOauth2TokenPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V1LoginProjectProjectIdOauth2TokenPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // The OAuth 2.0 Token Endpoint
    ApiResponse<OAuth2Token> response = apiInstance.V1LoginProjectProjectIdOauth2TokenPostWithHttpInfo(projectId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdOauth2TokenPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |

### Return type

[**OAuth2Token**](OAuth2Token.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v1loginprojectprojectiduserinfoget"></a>
# **V1LoginProjectProjectIdUserinfoGet**
> GetUserInfo V1LoginProjectProjectIdUserinfoGet (string projectId)

OpenID Connect Userinfo

This endpoint returns the payload of the ID Token,  including session.id_token values, of the provided  OAuth 2.0 Access Token's consent request. In the case of authentication error, a WWW-Authenticate  header might be set in the response with more information  about the error. See the spec for more details about  header format. 

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
    public class V1LoginProjectProjectIdUserinfoGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IdpApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 

            try
            {
                // OpenID Connect Userinfo
                GetUserInfo result = apiInstance.V1LoginProjectProjectIdUserinfoGet(projectId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdUserinfoGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V1LoginProjectProjectIdUserinfoGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // OpenID Connect Userinfo
    ApiResponse<GetUserInfo> response = apiInstance.V1LoginProjectProjectIdUserinfoGetWithHttpInfo(projectId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdUserinfoGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |

### Return type

[**GetUserInfo**](GetUserInfo.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v1loginprojectprojectidwellknownjwksjsonget"></a>
# **V1LoginProjectProjectIdWellKnownJwksJsonGet**
> JsonWebKey V1LoginProjectProjectIdWellKnownJwksJsonGet (string projectId)

Discover Well-Known JSON Web Keys

This endpoint returns JSON Web Keys required to verifying OpenID Connect ID Tokens and, if enabled, OAuth 2.0 JWT Access Tokens. This endpoint can be used with client libraries like node-jwks-rsa among others.

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
    public class V1LoginProjectProjectIdWellKnownJwksJsonGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IdpApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 

            try
            {
                // Discover Well-Known JSON Web Keys
                JsonWebKey result = apiInstance.V1LoginProjectProjectIdWellKnownJwksJsonGet(projectId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdWellKnownJwksJsonGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V1LoginProjectProjectIdWellKnownJwksJsonGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Discover Well-Known JSON Web Keys
    ApiResponse<JsonWebKey> response = apiInstance.V1LoginProjectProjectIdWellKnownJwksJsonGetWithHttpInfo(projectId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdWellKnownJwksJsonGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |

### Return type

[**JsonWebKey**](JsonWebKey.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="v1loginprojectprojectidwellknownopenidconfigurationget"></a>
# **V1LoginProjectProjectIdWellKnownOpenidConfigurationGet**
> OIDCConfig V1LoginProjectProjectIdWellKnownOpenidConfigurationGet (string projectId)

OpenID Connect Discovery

A mechanism for an OpenID Connect Relying Party to discover the End-User's  OpenID Provider and obtain information needed to interact with it, including  its OAuth 2.0 endpoint locations. 

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
    public class V1LoginProjectProjectIdWellKnownOpenidConfigurationGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://apse1.api.affinidi.io/vpa";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new IdpApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 

            try
            {
                // OpenID Connect Discovery
                OIDCConfig result = apiInstance.V1LoginProjectProjectIdWellKnownOpenidConfigurationGet(projectId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdWellKnownOpenidConfigurationGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the V1LoginProjectProjectIdWellKnownOpenidConfigurationGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // OpenID Connect Discovery
    ApiResponse<OIDCConfig> response = apiInstance.V1LoginProjectProjectIdWellKnownOpenidConfigurationGetWithHttpInfo(projectId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IdpApi.V1LoginProjectProjectIdWellKnownOpenidConfigurationGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |

### Return type

[**OIDCConfig**](OIDCConfig.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


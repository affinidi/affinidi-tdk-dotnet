# AffinidiTdk.LoginConfigurationClient.Model.OAuth2Token

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccessToken** | **string** | The access token issued by the authorization server.  | [optional] 
**ExpiresIn** | **int** | The lifetime in seconds of the access token.  For example, the value \&quot;3600\&quot; denotes that the access  token will expire in one hour from the time the response was generated.  | [optional] 
**IdToken** | **int** | To retrieve a refresh token request the id_token scope.  | [optional] 
**RefreshToken** | **string** | The refresh token, which can be used to obtain new access tokens. To retrieve it add the scope \&quot;offline\&quot; to your access token request.  | [optional] 
**Scope** | **string** | The scope of the access token  | [optional] 
**TokenType** | **string** | The type of the token issued  | [optional] 
**AuthorizationDetails** | [**List&lt;OAuth2TokenAuthorizationDetailsInner&gt;**](OAuth2TokenAuthorizationDetailsInner.md) | is used to request issuance of a certain Credential type. This optional field is only applicable in batch credential operations.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


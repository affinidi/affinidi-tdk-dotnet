# AffinidiTdk.LoginConfigurationClient.Model.LoginConfigurationObject

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Ari** | **string** | Configuration ari | 
**ConfigurationId** | **string** | Configuration id | [optional] 
**ProjectId** | **string** | Project id | 
**Name** | **string** | User defined login configuration name | 
**RedirectUris** | **List&lt;string&gt;** | OAuth 2.0 Redirect URIs | [optional] 
**PostLogoutRedirectUris** | **List&lt;string&gt;** | Post Logout Redirect URIs, Used to redirect the user&#39;s browser to a specified URL after the logout process is complete. Must match the domain, port, scheme of at least one of the registered redirect URIs | [optional] 
**Scope** | **string** | OAuth 2.0 Client Scope | [optional] 
**ClientId** | **string** | OAuth 2.0 Client ID | [optional] 
**CreationDate** | **string** | OAuth 2.0 Client Creation Date | 
**VpDefinition** | **string** | VP definition in JSON stringify format | [optional] 
**PresentationDefinition** | **Object** | Presentation Definition | [optional] 
**IdTokenMapping** | [**List&lt;IdTokenMappingItem&gt;**](IdTokenMappingItem.md) | Fields name/path mapping between the vp_token and the id_token | 
**ClientMetadata** | [**LoginConfigurationClientMetadataOutput**](LoginConfigurationClientMetadataOutput.md) |  | 
**TokenEndpointAuthMethod** | **TokenEndpointAuthMethod** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


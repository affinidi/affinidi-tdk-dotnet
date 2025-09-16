# AffinidiTdk.LoginConfigurationClient.Model.UpdateLoginConfigurationInput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | User defined login configuration name | [optional] 
**RedirectUris** | **List&lt;string&gt;** | OAuth 2.0 Redirect URIs | [optional] 
**PostLogoutRedirectUris** | **List&lt;string&gt;** | Post Logout Redirect URIs, Used to redirect the user&#39;s browser to a specified URL after the logout process is complete. Must match the domain, port, scheme of at least one of the registered redirect URIs | [optional] 
**ClientSecret** | **string** | OAuth2 client secret | [optional] 
**VpDefinition** | **string** | VP definition in JSON stringify format | [optional] 
**PresentationDefinition** | **Object** | Presentation Definition | [optional] 
**IdTokenMapping** | [**List&lt;IdTokenMappingItem&gt;**](IdTokenMappingItem.md) | Fields name/path mapping between the vp_token and the id_token | [optional] 
**ClientMetadata** | [**LoginConfigurationClientMetadataInput**](LoginConfigurationClientMetadataInput.md) |  | [optional] 
**TokenEndpointAuthMethod** | **TokenEndpointAuthMethod** |  | [optional] 
**FailOnMappingConflict** | **bool** | Interrupts login process if duplications of data fields names will be found | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


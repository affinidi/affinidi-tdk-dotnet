# AffinidiTdk.LoginConfigurationClient.Model.CreateLoginConfigurationInput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | User defined login configuration name | 
**Description** | **string** |  | [optional] 
**RedirectUris** | **List&lt;string&gt;** | OAuth 2.0 Redirect URIs | 
**PostLogoutRedirectUris** | **List&lt;string&gt;** | Post Logout Redirect URIs, Used to redirect the user&#39;s browser to a specified URL after the logout process is complete. Must match the domain, port, scheme of at least one of the registered redirect URIs | [optional] 
**VpDefinition** | **string** | VP definition in JSON stringify format | [optional] 
**PresentationDefinition** | **Object** | Presentation Definition | [optional] 
**DcqlQuery** | **Object** | DCQL query in JSON stringify format | [optional] 
**IdTokenMapping** | [**List&lt;IdTokenMappingItem&gt;**](IdTokenMappingItem.md) | Fields name/path mapping between the vp_token and the id_token | [optional] 
**ClientMetadata** | [**LoginConfigurationClientMetadataInput**](LoginConfigurationClientMetadataInput.md) |  | [optional] 
**ClaimFormat** | **string** | ID token claims output format. Default is array. | [optional] 
**FailOnMappingConflict** | **bool** | Interrupts login process if duplications of data fields names will be found | [optional] [default to true]
**Scope** | **string** | List of groups separated by space | [optional] 
**TokenEndpointAuthMethod** | **TokenEndpointAuthMethod** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


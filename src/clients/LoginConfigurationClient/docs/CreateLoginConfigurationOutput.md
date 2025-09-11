# AffinidiTdk.LoginConfigurationClient.Model.CreateLoginConfigurationOutput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Ari** | **string** | Configuration ari | 
**ProjectId** | **string** | Project id | 
**ConfigurationId** | **string** | Configuration id | [optional] 
**Name** | **string** | User defined login configuration name | 
**Auth** | [**CreateLoginConfigurationOutputAuth**](CreateLoginConfigurationOutputAuth.md) |  | 
**RedirectUris** | **List&lt;string&gt;** | OAuth 2.0 Redirect URIs | 
**ClientMetadata** | [**LoginConfigurationClientMetadataOutput**](LoginConfigurationClientMetadataOutput.md) |  | 
**CreationDate** | **string** | OAuth 2.0 Client Creation Date | 
**PostLogoutRedirectUris** | **List&lt;string&gt;** | Post Logout Redirect URIs, Used to redirect the user&#39;s browser to a specified URL after the logout process is complete. Must match the domain, port, scheme of at least one of the registered redirect URIs | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


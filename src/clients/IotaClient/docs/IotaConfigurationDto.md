# AffinidiTdk.IotaClient.Model.IotaConfigurationDto

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Ari** | **string** | This is a unique resource identifier of the Affinidi Iota Framework configuration. | 
**ConfigurationId** | **string** | ID of the Affinidi Iota Framework configuration. | 
**Name** | **string** | The name of the configuration to quickly identify the resource. | 
**ProjectId** | **string** | The ID of the project. | 
**WalletAri** | **string** | The unique resource identifier of the Wallet used to sign the request token. | 
**TokenMaxAge** | **decimal** | This is the lifetime of the signed request token during the data-sharing flow. | 
**IotaResponseWebhookURL** | **string** | The webhook URL is used for callback when the data is ready. | [optional] 
**EnableVerification** | **bool** | Cryptographically verifies the data shared by the user when enabled. | 
**EnableConsentAuditLog** | **bool** | Records the consent the user gave when they shared their data, including the type of data shared. | 
**ClientMetadata** | [**IotaConfigurationDtoClientMetadata**](IotaConfigurationDtoClientMetadata.md) |  | 
**Mode** | **string** | Determines whether to handle the data-sharing request using the WebSocket or Redirect flow. | [optional] [default to ModeEnum.Websocket]
**RedirectUris** | **List&lt;string&gt;** | List of allowed URLs to redirect users, including the response from the request. This is required if the selected data-sharing mode is Redirect. | [optional] 
**EnableIdvProviders** | **bool** | Enables identity verification from user with a 3rd-party provider when a verified identity document is not found. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


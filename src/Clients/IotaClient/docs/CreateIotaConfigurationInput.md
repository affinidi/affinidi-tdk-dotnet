# AffinidiTdk.IotaClient.Model.CreateIotaConfigurationInput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | The name of the configuration to quickly identify the resource. | 
**Description** | **string** | An optional description of what the configuration is used for. | [optional] 
**WalletAri** | **string** | The unique resource identifier of the Wallet used to sign the request token. | 
**IotaResponseWebhookURL** | **string** | The webhook URL is used for callback when the data is ready. | [optional] 
**EnableVerification** | **bool** | Cryptographically verifies the data shared by the user when enabled. | 
**EnableConsentAuditLog** | **bool** | Records the user&#39;s consent when they share their data, including the type of data shared when enabled. | 
**TokenMaxAge** | **decimal** | This is the lifetime of the signed request token during the data-sharing flow. | [optional] 
**ClientMetadata** | [**IotaConfigurationDtoClientMetadata**](IotaConfigurationDtoClientMetadata.md) |  | 
**Mode** | **string** | Determines whether to handle the data-sharing request using the WebSocket, Redirect or Didcomm messaging flow. | [optional] [default to ModeEnum.Websocket]
**RedirectUris** | **List&lt;string&gt;** | List of allowed URLs to redirect users, including the response from the request. This is required if the selected data-sharing mode is Redirect. | [optional] 
**EnableIdvProviders** | **bool** | Enables identity verification from user with a 3rd-party provider when a verified identity document is not found. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


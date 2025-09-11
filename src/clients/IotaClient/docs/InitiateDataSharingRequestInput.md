# AffinidiTdk.IotaClient.Model.InitiateDataSharingRequestInput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**QueryId** | **string** | The ID of the query. | 
**CorrelationId** | **string** | A unique, randomly generated identifier that correlates the request and response in the data-sharing request flow. | 
**TokenMaxAge** | **decimal** | This is the lifetime of the signed request token during the data-sharing flow. | [optional] 
**Nonce** | **string** | A randomly generated value that is added in the request and response to prevent replay attacks. | 
**RedirectUri** | **string** | List of allowed URLs to redirect users, including the response from the request. This is required if the selected data-sharing mode is Redirect. | 
**ConfigurationId** | **string** | ID of the Affinidi Iota Framework configuration. | 
**Mode** | **string** | Determines whether to handle the data-sharing request using the WebSocket or Redirect flow. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


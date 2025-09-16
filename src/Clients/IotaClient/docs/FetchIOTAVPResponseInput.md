# AffinidiTdk.IotaClient.Model.FetchIOTAVPResponseInput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CorrelationId** | **string** | A unique, randomly generated identifier that correlates the request and response in the data-sharing request flow. | 
**TransactionId** | **string** | A unique, randomly generated identifier data-sharing request flow is initiated. This value is used with the response code to fetch the callback response data. | 
**ResponseCode** | **string** | A unique identifier to fetch the callback response data. Send this value together with the transactionId to successfully fetch the data. | 
**ConfigurationId** | **string** | ID of the Affinidi Iota Framework configuration. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


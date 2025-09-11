# AffinidiTdk.CredentialIssuanceClient.Model.FlowData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedAt** | **string** | [GEN] ISO 8601 string of the creation date/time the entity | 
**ModifiedAt** | **string** | [GEN] ISO 8601 string of the modification date/time the entity | 
**Id** | **string** |  | 
**ProjectId** | **string** |  | [optional] 
**FlowId** | **string** |  | 
**CredentialTypeId** | **string** |  | 
**JsonLdContextUrl** | **string** |  | 
**JsonSchemaUrl** | **string** |  | 
**ConfigurationId** | **string** | Id of configuration, used to issue VC. | [optional] 
**IssuedAt** | **string** | when credential was issued to the holder (holder invoked generateCredentials endpoint) | [optional] 
**WalletId** | **string** | Id of wallet, used to issue VC. | [optional] 
**ProjectIdConfigurationId** | **string** | Id of configuration with which VC was issued. To use as an index, it is grouped together with projectId, as \&quot;{projectIdConfigurationId}#{configurationId}\&quot; | [optional] 
**ProjectIdConfigurationIdWalletId** | **string** | Id of wallet which issued VC. To use as an index, it is grouped together with projectId, as \&quot;{projectIdConfigurationId}#{walletId}\&quot; | [optional] 
**ProjectIdConfigurationIdCredentialType** | **string** | VC.type value. To use as an index, it is grouped together with projectId, as \&quot;{projectIdConfigurationId}#{credentialType}\&quot; | [optional] 
**StatusListsDetails** | [**List&lt;FlowDataStatusListsDetailsInner&gt;**](FlowDataStatusListsDetailsInner.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


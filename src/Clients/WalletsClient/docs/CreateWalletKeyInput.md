# AffinidiTdk.WalletsClient.Model.CreateWalletKeyInput
Input for adding a new key to a wallet. Only supported for did:web ATM.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Algorithm** | **string** | cryptographic algorithm for the new key | [optional] 
**KeyType** | **string** | Deprecated alias of &#x60;algorithm&#x60;. Accepted for backward compatibility; prefer &#x60;algorithm&#x60;. If both are sent, &#x60;algorithm&#x60; takes precedence. | [optional] 
**Relationships** | [**List&lt;VerificationRelationship&gt;**](VerificationRelationship.md) | verification relationships for the key. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


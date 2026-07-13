# AffinidiTdk.WalletsClient.Model.WalletKeyDto
Detailed information about a wallet key. Multiple keys are only supported for did:web wallets.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**KeyId** | **string** | wallet-scoped key identifier (e.g., \&quot;key-1\&quot;) | [optional] 
**Algorithm** | **string** | cryptographic algorithm used by this key | [optional] 
**KeyType** | **string** | Deprecated alias of &#x60;algorithm&#x60;. Always equal to &#x60;algorithm&#x60; and included for backward compatibility. | [optional] 
**KeyAri** | **string** | ARI identifier for the key (e.g., \&quot;ari:key:...\&quot;) | [optional] 
**Relationships** | [**List&lt;VerificationRelationship&gt;**](VerificationRelationship.md) | verification relationships this key supports | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


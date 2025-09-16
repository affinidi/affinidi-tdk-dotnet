# AffinidiTdk.CredentialIssuanceClient.Model.CredentialResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Credential** | [**CredentialResponseImmediateCredential**](CredentialResponseImmediateCredential.md) |  | 
**CNonce** | **string** | String containing a nonce to be used when creating a proof of possession of the key proof | 
**CNonceExpiresIn** | **decimal** | Lifetime in seconds of the c_nonce | 
**TransactionId** | **string** | String identifying a Deferred Issuance transaction. This claim is contained in the response if the Credential Issuer was unable to immediately issue the Credential. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


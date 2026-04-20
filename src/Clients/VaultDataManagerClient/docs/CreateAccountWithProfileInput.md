# AffinidiTdk.VaultDataManagerClient.Model.CreateAccountWithProfileInput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountIndex** | **decimal** | number that is used for profile DID derivation | 
**AccountDid** | **string** | DID that is associated with the account number | 
**DidProof** | **string** | JWT that proves ownership of profile DID by requester | 
**Alias** | **string** | Alias of account | [optional] 
**AccountMetadata** | **Object** | Metadata of account | [optional] 
**AccountDescription** | **string** | Description of account | [optional] 
**ProfileName** | **string** | Name of the profile node | 
**ProfileDescription** | **string** | Description of the profile node | [optional] 
**ProfileMetadata** | **Object** | Metadata of the profile | [optional] 
**EdekInfo** | [**EdekInfo**](EdekInfo.md) |  | 
**Dek** | **string** | A base64 encoded data encryption key, encrypted using VFS public key | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


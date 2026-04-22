# AffinidiTdk.VaultDataManagerClient.Model.PatchAccountInput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DidProof** | **string** | JWT that proves ownership of profile DID by requester | 
**EncryptedDekek** | **string** | A base64 encoded data encryption key, encrypted using VFS public key, required for PATCH operation on account | 
**OwnerProfileId** | **string** | A unique identifier of profile, required for PATCH operation on account | 
**OwnerProfileDid** | **string** | DID that is associated with the profile, required for PATCH operation on account | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


# AffinidiTdk.WalletsClient.Model.SignCredentialsLdpInputDto
DTO contains params to sign credential

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UnsignedCredential** | **Object** | Unsigned Credential in Dm2 format  | 
**Revocable** | **bool** |  | [optional] 
**SignatureScheme** | **string** |  | [optional] 
**SignatureSuite** | **string** | W3C signature suite for canonicalization. Defaults to rdfc variants for each algorithm (ecdsa-rdfc-2019 for P256, eddsa-rdfc-2022 for Ed25519, EcdsaSecp256k1Signature2019 for secp256k1). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


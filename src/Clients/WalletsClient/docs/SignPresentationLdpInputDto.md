# AffinidiTdk.WalletsClient.Model.SignPresentationLdpInputDto
DTO contains params to sign presentation

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UnsignedPresentation** | **Object** | Unsigned presentation in Dm1 format | 
**SignatureScheme** | **string** |  | [optional] 
**SignatureSuite** | **string** | W3C signature suite for canonicalization. Defaults to rdfc variants for each algorithm (ecdsa-rdfc-2019 for P256, eddsa-rdfc-2022 for Ed25519, EcdsaSecp256k1Signature2019 for secp256k1). | [optional] 
**Domain** | **List&lt;string&gt;** | Domain(s) for which the presentation is intended | [optional] 
**Challenge** | **string** | Challenge string | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


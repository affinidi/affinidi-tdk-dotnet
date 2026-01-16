# AffinidiTdk.CredentialVerificationClient.Model.VerifyPresentationV2Input
Request model of /v2/verify-vp

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**VerifiablePresentation** | **Object** |  | [optional] 
**PexQuery** | [**VerifyPresentationV2InputPexQuery**](VerifyPresentationV2InputPexQuery.md) |  | [optional] 
**DcqlQuery** | **Dictionary&lt;string, Object&gt;** | DCQL (Digital Credentials Query Language) Query used to verify that the credentials in the Verifiable Presentation match the specified query requirements. Currently supports only ldp_vc format credentials. Developers should implement additional business rule validation on top of the verification results returned by this service. | [optional] 
**Challenge** | **string** | Optional challenge string for domain/challenge verification | [optional] 
**Domain** | **List&lt;string&gt;** | Optional domain for verification. Array of domain strings as per W3C VP standard | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


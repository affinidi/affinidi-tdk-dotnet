# AffinidiTdk.CredentialIssuanceClient.Model.IssuanceConfigDto

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] 
**Name** | **string** |  | [optional] 
**Description** | **string** |  | [optional] 
**IssuerDid** | **string** | Issuer DID | [optional] 
**IssuerWalletId** | **string** | Issuer Wallet id | [optional] 
**CredentialOfferDuration** | **decimal** | credential offer duration in second | [optional] 
**CNonceDuration** | **decimal** | c_nonce duration in second | [optional] 
**Format** | **string** | String identifying the format of this Credential, i.e., jwt_vc_json-ld or ldp_vc. Depending on the format value, the object contains further elements defining the type | [optional] 
**IssuerUri** | **string** | Issuer URI | [optional] 
**CredentialSupported** | [**List&lt;CredentialSupportedObject&gt;**](CredentialSupportedObject.md) |  | [optional] 
**IssuerMetadata** | **Dictionary&lt;string, Object&gt;** | Issuer public information wallet may want to show to user during consent confirmation | [optional] 
**VarVersion** | **decimal** |  | [optional] 
**ReturnUris** | **List&lt;string&gt;** | List of allowed URIs to be returned to after issuance | [optional] 
**Webhook** | [**CisConfigurationWebhookSetting**](CisConfigurationWebhookSetting.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


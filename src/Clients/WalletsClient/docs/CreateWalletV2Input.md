# AffinidiTdk.WalletsClient.Model.CreateWalletV2Input

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | The name of the wallet | [optional] 
**Description** | **string** | The description of the wallet | [optional] 
**DidMethod** | **string** | Define how DID of your wallet is created and resolved | [optional] [default to DidMethodEnum.Key]
**DidWebUrl** | **string** | URL of the DID. Required if the did method is web | [optional] 
**Algorithm** | **string** | algorithm to generate key for the wallet | [optional] [default to AlgorithmEnum.Secp256k1]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


# AffinidiTdk.VaultDataManagerClient.Model.CreateNodeInput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the item | 
**Type** | **NodeType** |  | 
**Description** | **string** | description of profile if creating a new profile | [optional] 
**ParentNodeId** | **string** | parent node id, if not provided then root element is used | [optional] 
**EdekInfo** | [**EdekInfo**](EdekInfo.md) |  | [optional] 
**Dek** | **string** | A base64 encoded data encryption key, encrypted using VFS public key, required for node types [FILE, PROFILE] | [optional] 
**Metadata** | **string** | metadata of the node in stringified json format | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


# AffinidiTdk.VaultDataManagerClient.Model.GetDetailedNodeInfoOK

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**NodeId** | **string** | A unique identifier of current node | 
**Status** | **NodeStatus** |  | 
**FileCount** | **decimal** | number of files in current node | [optional] 
**ProfileCount** | **decimal** | number of profiles in current node | [optional] 
**FolderCount** | **decimal** | number of folders in current node | [optional] 
**VcCount** | **decimal** | number of vcCount in current node | [optional] 
**Name** | **string** | display name of current node | 
**ConsumerId** | **string** | unique identifier for consumer | 
**ParentNodeId** | **string** | parent node path | 
**ProfileId** | **string** | A unique identifier of profile, under which current node is created | 
**CreatedAt** | **string** | creation date/time of the node | 
**ModifiedAt** | **string** | modification date/time of the node | 
**CreatedBy** | **string** | Identifier of the user who created the node | 
**ModifiedBy** | **string** | Identifier of the user who last updated the node | 
**Description** | **string** | Description of the node | [optional] 
**Type** | **NodeType** |  | 
**Link** | **string** | id of the file, used for FILE node only | [optional] 
**Schema** | **string** | name of the schema, used for PROFILE node only | [optional] 
**ConsumedFileStorage** | **decimal** | amount of bytes used by the stored data, used for ROOT_ELEMENT only for now | [optional] 
**EdekInfo** | [**EdekInfo**](EdekInfo.md) |  | [optional] 
**Metadata** | **string** | A JSON string format containing metadata of the node | [optional] 
**GetUrl** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


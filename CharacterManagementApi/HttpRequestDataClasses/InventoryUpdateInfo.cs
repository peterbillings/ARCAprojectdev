using System;

namespace CharacterManagementApi.HttpRequestDataClasses
{
    public class InventoryUpdateInfo
    {
        public string CharacterName {get; set;}
        public string ItemName {get; set;}
        public int ItemValue {get; set;}
        public int ItemQuantity {get; set;}
        public string ItemDescription {get; set;}
    }
}
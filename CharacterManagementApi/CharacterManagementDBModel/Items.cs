using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class Items
    {
        public Items()
        {
            CharacterInventory = new HashSet<CharacterInventory>();
        }

        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemValue { get; set; }

        public virtual ICollection<CharacterInventory> CharacterInventory { get; set; }
    }
}

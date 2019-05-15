using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class CharacterInventory
    {
        public string CharacterName { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }

        public virtual CharacterDetails CharacterNameNavigation { get; set; }
        public virtual Items ItemNameNavigation { get; set; }
    }
}

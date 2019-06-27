using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class CharacterClass
    {
        public CharacterClass()
        {
            CharacterDetails = new HashSet<CharacterDetails>();
        }

        public string CharacterClass1 { get; set; }

        public virtual ICollection<CharacterDetails> CharacterDetails { get; set; }
    }
}

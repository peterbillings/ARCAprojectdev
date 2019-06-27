using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class HitDice
    {
        public HitDice()
        {
            CharacterDetails = new HashSet<CharacterDetails>();
        }

        public string HitDice1 { get; set; }

        public virtual ICollection<CharacterDetails> CharacterDetails { get; set; }
    }
}

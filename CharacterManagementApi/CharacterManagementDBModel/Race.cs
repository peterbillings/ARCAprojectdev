using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class Race
    {
        public Race()
        {
            CharacterDetails = new HashSet<CharacterDetails>();
        }

        public string Race1 { get; set; }

        public virtual ICollection<CharacterDetails> CharacterDetails { get; set; }
    }
}

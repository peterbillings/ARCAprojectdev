using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class Alignment
    {
        public Alignment()
        {
            CharacterDetails = new HashSet<CharacterDetails>();
        }

        public string Alignment1 { get; set; }

        public virtual ICollection<CharacterDetails> CharacterDetails { get; set; }
    }
}

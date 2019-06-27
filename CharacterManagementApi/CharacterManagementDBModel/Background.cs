using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class Background
    {
        public Background()
        {
            CharacterDetails = new HashSet<CharacterDetails>();
        }

        public string Background1 { get; set; }

        public virtual ICollection<CharacterDetails> CharacterDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class SchoolOfMagic
    {
        public SchoolOfMagic()
        {
            Spells = new HashSet<Spells>();
        }

        public string SchoolOfMagic1 { get; set; }

        public virtual ICollection<Spells> Spells { get; set; }
    }
}

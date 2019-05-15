using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class Spells
    {
        public Spells()
        {
            CharacterSpells = new HashSet<CharacterSpells>();
        }

        public string SpellName { get; set; }
        public short SpellLevel { get; set; }
        public string SchoolOfMagic { get; set; }
        public string SpellCastingTime { get; set; }
        public bool Ritual { get; set; }
        public string SpellRange { get; set; }
        public string SpellComponents { get; set; }
        public string SpellDuration { get; set; }
        public string SpellDescription { get; set; }

        public virtual ICollection<CharacterSpells> CharacterSpells { get; set; }
    }
}

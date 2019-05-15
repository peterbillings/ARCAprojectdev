using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class CharacterSpells
    {
        public string CharacterName { get; set; }
        public string SpellName { get; set; }

        public virtual CharacterDetails CharacterNameNavigation { get; set; }
        public virtual Spells SpellNameNavigation { get; set; }
    }
}

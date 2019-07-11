using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class CharacterStatus
    {
        public string CharacterName { get; set; }
        public int CurrentHp { get; set; }
        public int TempHp { get; set; }
        public int Gold { get; set; }
        public int Exhaustion { get; set; }
        public string Condition { get; set; }
        public int Perception { get; set; }

        public virtual CharacterDetails CharacterNameNavigation { get; set; }
    }
}

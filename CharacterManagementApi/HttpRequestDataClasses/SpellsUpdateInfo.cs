using System;

namespace CharacterManagementApi.HttpRequestDataClasses
{
    public class SpellsUpdateInfo
    {
        public string CharacterName {get; set;}
        public string SpellName {get; set;}
        public int SpellLevel {get; set;}
        public string SchoolOfMagic {get; set;}
        public string SpellCastingTime {get; set;}
        public bool Ritual {get; set;}
        public string SpellRange {get; set;}
        public string SpellComponents {get; set;}
        public string SpellDuration {get; set;}
        public string SpellDescription {get; set;}
    }
}
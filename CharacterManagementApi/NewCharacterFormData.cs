using System;

namespace CharacterManagementApi
{
    public class NewCharacterFormData
    {

        public string CharacterName {get; set;}
        public string PlayerName {get; set;}
        public string Race {get; set;}
        public string CharacterClass {get; set;}
        public string Background {get; set;}
        public string Alignment {get; set;}
        public int Level {get; set;}
        public int Experience {get; set;}
        public int Strength {get; set;}
        public int StengthMod {get; set;}
        public int Dexterity {get; set;}
        public int DexterityMod {get; set;}
        public int Constitution {get; set;}
        public int ConstitutionMod {get; set;}

        // resume work here!!!
        public NewCharacterFormData()
        {

        }
    }
}
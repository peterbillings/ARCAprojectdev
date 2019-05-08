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
        public int Intelligence {get; set;}
        public int IntelligenceMod {get; set;}
        public int Wisdom {get; set;}
        public int WisdomMod {get; set;}
        public int Charisma {get; set;}
        public int CharismaMod {get; set;}
        public int MaxHp {get; set;}
        public int ArmorClass {get; set;}
        public string HitDice {get; set;}
        public int HitDiceTotal {get; set;}
        public int ProficiencyBonus {get; set;}
        public int PassivePerception {get; set;}
        public int Initiative {get; set;}
        public int Speed {get; set;}
        public string PersonalityTraits {get; set;}
        public string Ideals {get; set;}
        public string Bonds {get; set;}
        public string Flaws {get; set;}
        public string AdditionalFeatures {get; set;}
        public string Languages {get; set;}
        public int Acrobatics {get; set;} = 0;
        public int AnimalHandling {get; set;} = 0;
        public int Arcana {get; set;} = 0;
        public int Athletics {get; set;} = 0;
        public int Deception {get; set;} = 0;
        public int History {get; set;} = 0;
        public int Insight {get; set;} = 0;
        public int Intimidation {get; set;} = 0;
        public int Investigation {get; set;} = 0;
        public int Medicine {get; set;} = 0;
        public int Nature {get; set;} = 0;
        public int Perception {get; set;} = 0;
        public int Performance {get; set;} = 0;
        public int Persuasion {get; set;} = 0;
        public int Religion {get; set;} = 0;
        public int SleightOfHand {get; set;} = 0;
        public int Stealth {get; set;} = 0;
        public int Survival {get; set;} = 0;
        public int StrengthSave {get; set;} = 0;
        public int DexteritySave {get; set;} = 0;
        public int ConstitutionSave {get; set;} = 0;
        public int IntelligenceSave {get; set;} = 0;
        public int WisdomSave {get; set;} = 0;
        public int CharismaSave {get; set;} = 0;

        public NewCharacterFormData()
        {

        }
    }
}
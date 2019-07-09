using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class CharacterDetails
    {
        public CharacterDetails()
        {
            CharacterInventory = new HashSet<CharacterInventory>();
            CharacterSpells = new HashSet<CharacterSpells>();
        }

        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public string Race { get; set; }
        public string CharacterClass { get; set; }
        public string Background { get; set; }
        public string Alignment { get; set; }
        public short CharacterLevel { get; set; }
        public int Experience { get; set; }
        public short Strength { get; set; }
        public short StrengthMod { get; set; }
        public short Dexterity { get; set; }
        public short DexterityMod { get; set; }
        public short Constitution { get; set; }
        public short ConstitutionMod { get; set; }
        public short Intelligence { get; set; }
        public short IntelligenceMod { get; set; }
        public short Wisdom { get; set; }
        public short WisdomMod { get; set; }
        public short Charisma { get; set; }
        public short CharismaMod { get; set; }
        public short MaxHp { get; set; }
        public short ArmorClass { get; set; }
        public string HitDice { get; set; }
        public short HitDiceTotal { get; set; }
        public short ProficiencyBonus { get; set; }
        public short PassivePerception { get; set; }
        public short Initiative { get; set; }
        public short Speed { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public string AdditionalFeatures { get; set; }
        public string Languages { get; set; }
        public bool Acrobatics { get; set; }
        public bool AnimalHandling { get; set; }
        public bool Arcana { get; set; }
        public bool Athletics { get; set; }
        public bool Deception { get; set; }
        public bool History { get; set; }
        public bool Insight { get; set; }
        public bool Intimidation { get; set; }
        public bool Investigation { get; set; }
        public bool Medicine { get; set; }
        public bool Nature { get; set; }
        public bool Perception { get; set; }
        public bool Performance { get; set; }
        public bool Persuasion { get; set; }
        public bool Religion { get; set; }
        public bool SleightOfHand { get; set; }
        public bool Stealth { get; set; }
        public bool Survival { get; set; }
        public bool StrengthSave { get; set; }
        public bool DexteritySave { get; set; }
        public bool ConstitutionSave { get; set; }
        public bool IntelligenceSave { get; set; }
        public bool WisdomSave { get; set; }
        public bool CharismaSave { get; set; }

        public virtual Alignment AlignmentNavigation { get; set; }
        public virtual Background BackgroundNavigation { get; set; }
        public virtual CharacterClass CharacterClassNavigation { get; set; }
        public virtual HitDice HitDiceNavigation { get; set; }
        public virtual Race RaceNavigation { get; set; }
        public virtual CharacterStatus CharacterStatus { get; set; }
        public virtual ICollection<CharacterInventory> CharacterInventory { get; set; }
        public virtual ICollection<CharacterSpells> CharacterSpells { get; set; }
    }
}

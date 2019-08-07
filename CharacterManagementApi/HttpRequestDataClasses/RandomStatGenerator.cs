using System;
using System.Collections.Generic;
using System.Linq;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.HttpRequestDataClasses
{
    public class RandomStatGenerator
    {
        public string Race { get; set; }
        public string CharacterClass { get; set; }
        public string Background { get; set; }
        public string Alignment { get; set; }
        public int CharacterLevel { get; set; }
        public int Experience { get; set; }
        public int Strength { get; set; }
        public int StrengthMod { get; set; }
        public int Dexterity { get; set; }
        public int DexterityMod { get; set; }
        public int Constitution { get; set; }
        public int ConstitutionMod { get; set; }
        public int Intelligence { get; set; }
        public int IntelligenceMod { get; set; }
        public int Wisdom { get; set; }
        public int WisdomMod { get; set; }
        public int Charisma { get; set; }
        public int CharismaMod { get; set; }
        public int MaxHp { get; set; }
        public int ArmorClass { get; set; }
        public string HitDice { get; set; }
        public int HitDiceTotal { get; set; }
        public int ProficiencyBonus { get; set; }
        public int PassivePerception { get; set; }
        public int Initiative { get; set; }
        public int Speed { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public string AdditionalFeatures { get; set; }
        public string Languages { get; set; }
        public string[] SavingThrows {get; set;}

        public RandomStatGenerator()
        {
            this.Race = RandomRace();

            this.CharacterClass = RandomCharacterClass();

            this.Background = RandomBackground();

            this.Alignment = RandomAlignment();

            this.CharacterLevel = 1;

            this.Experience = 0;

            List<int> randomAbilityScores = RandomAbilityScores();

            this.Strength = randomAbilityScores[0];

            this.StrengthMod = AbilityScoreModifier(randomAbilityScores[0]);

            this.Dexterity = randomAbilityScores[1];

            this.DexterityMod = AbilityScoreModifier(randomAbilityScores[1]);

            this.Constitution = randomAbilityScores[2];

            this.ConstitutionMod = AbilityScoreModifier(randomAbilityScores[2]);

            this.Intelligence = randomAbilityScores[3];

            this.IntelligenceMod = AbilityScoreModifier(randomAbilityScores[3]);

            this.Wisdom = randomAbilityScores[4];

            this.WisdomMod = AbilityScoreModifier(randomAbilityScores[4]);

            this.Charisma = randomAbilityScores[5];

            this.CharismaMod = AbilityScoreModifier(randomAbilityScores[5]);

            this.MaxHp = RandomMaxHp();

            this.ArmorClass = 10 + this.DexterityMod;

            this.HitDice = RandomHitDice();

            this.HitDiceTotal = 1;

            this.ProficiencyBonus = 2;

            this.PassivePerception = 10 + this.WisdomMod;

            this.Initiative = this.DexterityMod;

            this.Speed = RandomSpeed();

            this.PersonalityTraits = "Add your desired personality!";

            this.Ideals = "What are your ideals?";

            this.Bonds = "What is your reason to exist?";

            this.Flaws = "What are your shortcomings?";

            this.AdditionalFeatures = "Add anything else interesting about yourself!";

            this.Languages = "Common";

            this.SavingThrows = new string[2];

            DetermineSavingThrows(this.SavingThrows, randomAbilityScores);
        }

        private string RandomRace()
        {
            Random random = new Random();

            List<string> listOfRaces = new List<string>();

            using(var context = new CharacterManagementDBContext())
            {
                var allRaces = context.Race
                                        .OrderBy(races => races.Race1)
                                        .Select(races => new {races.Race1});
                                        
                foreach (var race in allRaces)
                {
                    listOfRaces.Add(race.Race1);
                }
            }

            return listOfRaces[random.Next(listOfRaces.Count)];
        }

        private string RandomCharacterClass()
        {
            Random random = new Random();

            List<string> listOfClasses = new List<string>();

            using(var context = new CharacterManagementDBContext())
            {
                var allClasses = context.CharacterClass
                                        .OrderBy(characterClass => characterClass.CharacterClass1)
                                        .Select(characterClass => new {characterClass.CharacterClass1});
                                        
                foreach (var characterClass in allClasses)
                {
                    listOfClasses.Add(characterClass.CharacterClass1);
                }
            }

            return listOfClasses[random.Next(listOfClasses.Count)];
        }

        private string RandomBackground()
        {
            Random random = new Random();

            List<string> listOfBackgrounds = new List<string>();

            using(var context = new CharacterManagementDBContext())
            {
                var allBackgrounds = context.Background
                                        .OrderBy(background => background.Background1)
                                        .Select(background => new {background.Background1});
                                        
                foreach (var background in allBackgrounds)
                {
                    listOfBackgrounds.Add(background.Background1);
                }
            }

            return listOfBackgrounds[random.Next(listOfBackgrounds.Count)];
        }
        private string RandomAlignment()
        {
            Random random = new Random();

            List<string> listOfAlignments = new List<string>();

            using(var context = new CharacterManagementDBContext())
            {
                var allAlignments = context.Alignment
                                    .OrderBy(alignment => alignment.Alignment1)
                                    .Select(alignment => new {alignment.Alignment1});

                foreach (var alignment in allAlignments)
                {
                    listOfAlignments.Add(alignment.Alignment1);
                }
            }

            return listOfAlignments[random.Next(listOfAlignments.Count)];
        }

        private List<int> RandomAbilityScores()
        {
            Random random = new Random();
		
            int STR, DEX, CON, INT, WIS, CHA;
            
            do
            {
                STR = 8 + random.Next(10) + 1;
                DEX = 8 + random.Next(10) + 1;
                CON = 8 + random.Next(10) + 1;
                INT = 8 + random.Next(10) + 1;
                WIS = 8 + random.Next(10) + 1;
                CHA = 8 + random.Next(10) + 1;
            }
            while ( (STR + DEX + CON + INT + WIS + CHA) != 78 );
            
            return new List<int>() {STR, DEX, CON, INT, WIS, CHA};
        }

        private int RandomMaxHp()
        {
            Random random = new Random();

            int maxHp = 12 + random.Next(8) + 1;

            return maxHp;
        }

        private int AbilityScoreModifier(int abilityScore)
        {
            if ( (abilityScore - 10) % 2 != 0 )
            {
                abilityScore -= 1;
            }
            
            int modifier = (abilityScore - 10) / 2;
            
            return modifier;
        }

        private string RandomHitDice()
        {
            Random random = new Random();

            List<string> listOfHitDice = new List<string>();

            using(var context = new CharacterManagementDBContext())
            {
                var allHitDice = context.HitDice
                                    .OrderBy(hitDice => hitDice.HitDice1)
                                    .Select(hitDice => new {hitDice.HitDice1});

                foreach (var hitDice in allHitDice)
                {
                    listOfHitDice.Add(hitDice.HitDice1);
                }
            }

            return listOfHitDice[random.Next(listOfHitDice.Count)];
        }

        private int RandomSpeed()
        {
            Random random = new Random();

            int[] speeds = new int[] {25, 30, 35};

            return speeds[random.Next(speeds.Length)];
        }

        private void DetermineSavingThrows(string[] savingThrows, List<int> abilityScores)
        {
            string[] allSaves = new string[6]
            {
                "StrengthSave",
                "DexteritySave",
                "ConstitutionSave",
                "IntelligenceSave",
                "WisdomSave",
                "CharismaSave"
            };

            int[] sortedScores = new int[6];

            for (int i = 0; i < 6; i++)
            {
                sortedScores[i] = abilityScores[i];
            }

            Array.Sort(sortedScores);

            int firstSaveIndex = 0;

            for (int i = 0; i < 6; i++)
            {
                if(sortedScores[5] == abilityScores[i])
                {
                    savingThrows[0] = allSaves[i];

                    firstSaveIndex = i;

                    break;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if(sortedScores[4] == abilityScores[i] && i != firstSaveIndex)
                {
                    savingThrows[1] = allSaves[i];

                    break;
                }
            }
        }
    }
}
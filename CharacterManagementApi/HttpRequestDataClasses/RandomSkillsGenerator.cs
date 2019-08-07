using System;
using CharacterManagementApi.CharacterManagementDBModel;
using System.Collections.Generic;
using System.Reflection;

namespace CharacterManagementApi.HttpRequestDataClasses
{

    public class RandomSkillsGenerator
    {

        public List<string> AllSkills {get; set;}

        public List<string> RandomSkills {get; set;}

        public RandomSkillsGenerator()
        {
            this.AllSkills = new List<string>() 
            {
                "Acrobatics",
                "AnimalHandling",
                "Arcana",
                "Athletics",
                "Deception",
                "History",
                "Insight",
                "Intimidation",
                "Investigation",
                "Medicine",
                "Nature",
                "Perception",
                "Performance",
                "Persuasion",
                "Religion",
                "SleightOfHand",
                "Stealth",
                "Survival",
            };

            this.RandomSkills = new List<string>();

            DetermineRandomSkills(this.AllSkills, this.RandomSkills);
        }

        private void DetermineRandomSkills(List<string> all, List<string> chosen)
        {   
            Random random = new Random();

            int[] randomIndexes = new int[4];

            do
            {
                randomIndexes[0] = random.Next(all.Count);
                randomIndexes[1] = random.Next(all.Count);
                randomIndexes[2] = random.Next(all.Count);
                randomIndexes[3] = random.Next(all.Count);
            }
            while (randomIndexes[0] == randomIndexes[1] || randomIndexes[0] == randomIndexes[2] ||
                   randomIndexes[0] == randomIndexes[3] || randomIndexes[1] == randomIndexes[2] ||
                   randomIndexes[1] == randomIndexes[3] || randomIndexes[2] == randomIndexes[3]);

            foreach (int index in randomIndexes)
            {
                chosen.Add(all[index]);
            }
        }
    }
}

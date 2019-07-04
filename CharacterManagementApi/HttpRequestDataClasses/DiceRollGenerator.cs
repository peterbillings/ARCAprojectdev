using System;



namespace CharacterManagementApi.HttpRequestDataClasses
{
    public class DiceRollGenerator
    {
        int TotalDice {get; set;}

        int NumberOfSides {get; set;}

        int Modifier {get; set;}

        public DiceRollGenerator (int totalDice, int numberOfSides, int modifier)
        {
            this.TotalDice = totalDice;

            this.NumberOfSides = numberOfSides;

            this.Modifier = modifier;
        }

        public int RollDice()
        {   
            Random random = new Random();

            int sumOfDice = 0;

            sumOfDice += this.Modifier;

            for (int i = 0; i < this.TotalDice; i++)
            {
                sumOfDice += random.Next(this.NumberOfSides) + 1;
            }
                
            return sumOfDice;
        }
        
    }

}
using System;
using Microsoft.AspNetCore.Mvc;
using CharacterManagementApi.CharacterManagementDBModel;
using CharacterManagementApi.HttpRequestDataClasses;
using System.Reflection;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GenerateRandomStatsController : ControllerBase
    {
        [HttpGet]

        public ActionResult<CharacterDetails> Get()
        {
            CharacterDetails randomCharacter = new CharacterDetails();

            RandomStatGenerator randomStats = new RandomStatGenerator();

            RandomSkillsGenerator randomSkills = new RandomSkillsGenerator();

            randomCharacter.Race = randomStats.Race;

            randomCharacter.CharacterClass = randomStats.CharacterClass;

            randomCharacter.Background = randomStats.Background;

            randomCharacter.Alignment = randomStats.Alignment;

            randomCharacter.CharacterLevel = (short)randomStats.CharacterLevel;

            randomCharacter.Experience = randomStats.Experience;

            randomCharacter.Strength = (short)randomStats.Strength;

            randomCharacter.StrengthMod = (short)randomStats.StrengthMod;

            randomCharacter.Dexterity = (short)randomStats.Dexterity;

            randomCharacter.DexterityMod = (short)randomStats.DexterityMod;

            randomCharacter.Constitution = (short)randomStats.Constitution;

            randomCharacter.ConstitutionMod = (short)randomStats.ConstitutionMod;

            randomCharacter.Intelligence = (short)randomStats.Intelligence;

            randomCharacter.IntelligenceMod = (short)randomStats.IntelligenceMod;

            randomCharacter.Wisdom = (short)randomStats.Wisdom;

            randomCharacter.WisdomMod = (short)randomStats.WisdomMod;

            randomCharacter.Charisma = (short)randomStats.Charisma;

            randomCharacter.CharismaMod = (short)randomStats.CharismaMod;

            randomCharacter.MaxHp = (short)randomStats.MaxHp;

            randomCharacter.ArmorClass = (short)randomStats.ArmorClass;

            randomCharacter.HitDice = randomStats.HitDice;

            randomCharacter.HitDiceTotal = (short)randomStats.HitDiceTotal;

            randomCharacter.ProficiencyBonus = (short)randomStats.ProficiencyBonus;

            randomCharacter.PassivePerception = (short)randomStats.PassivePerception;

            randomCharacter.Initiative = (short)randomStats.Initiative;

            randomCharacter.Speed = (short)randomStats.Speed;

            randomCharacter.PersonalityTraits = randomStats.PersonalityTraits;

            randomCharacter.Ideals = randomStats.Ideals;
            
            randomCharacter.Bonds = randomStats.Bonds;

            randomCharacter.Flaws = randomStats.Flaws;

            randomCharacter.AdditionalFeatures = randomStats.AdditionalFeatures;

            randomCharacter.Languages = randomStats.Languages;

            foreach (string skill in randomSkills.RandomSkills)
            {
                PropertyInfo skillToUpdate = randomCharacter.GetType().GetProperty(skill);

                skillToUpdate.SetValue(randomCharacter, true, null);
            }

            foreach (string savingThrow in randomStats.SavingThrows)
            {
                PropertyInfo savingThrowToUpdate = randomCharacter.GetType().GetProperty(savingThrow);

                savingThrowToUpdate.SetValue(randomCharacter, true, null);
            }

            return randomCharacter;
        }
    }
}
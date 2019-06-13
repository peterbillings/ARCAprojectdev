using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;
using CharacterManagementApi.HttpRequestDataClasses;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateSpellsController : ControllerBase
    {
        
        [HttpPost]
        public ActionResult<string> Post([FromBody] SpellsUpdateInfo spellsUpdate)
        {
            Spells updateSpell = new Spells();

            updateSpell.SpellName = spellsUpdate.SpellName;
            updateSpell.SpellLevel = (short)spellsUpdate.SpellLevel;
            updateSpell.SchoolOfMagic = spellsUpdate.SchoolOfMagic;
            updateSpell.SpellCastingTime = spellsUpdate.SpellCastingTime;
            updateSpell.Ritual = spellsUpdate.Ritual;
            updateSpell.SpellRange = spellsUpdate.SpellRange;
            updateSpell.SpellComponents = spellsUpdate.SpellComponents;
            updateSpell.SpellDuration = spellsUpdate.SpellDuration;
            updateSpell.SpellDescription = spellsUpdate.SpellDescription;

            CharacterSpells spellListToUpdate = new CharacterSpells();

            spellListToUpdate.CharacterName = spellsUpdate.CharacterName;
            spellListToUpdate.SpellName = spellsUpdate.SpellName;

            try
            {
                using (var context = new CharacterManagementDBContext())
                {
                    if (! context.Spells.Any(spell => spell.SpellName == updateSpell.SpellName))
                    {
                        context.Spells.Add(updateSpell);
                    }

                    if (! context.CharacterSpells.Any(spellList => (spellList.CharacterName == spellListToUpdate.CharacterName &&
                                                                    spellList.SpellName == spellListToUpdate.SpellName)))
                    {
                        context.CharacterSpells.Add(spellListToUpdate);
                    }
                    else
                    {
                        return $"{spellsUpdate.CharacterName} already knows that spell!";
                    }

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Spells could not be updated. Please try again.";
            }
            catch(Exception)
            {
                return "Spells update failed.";
            }

            return $"{spellsUpdate.CharacterName}'s spell list updated successfully!";
        }
    }
}
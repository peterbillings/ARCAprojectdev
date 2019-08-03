using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UpdateSpellDetailsController : ControllerBase
    {
        [HttpPost]

        public ActionResult<string> Post([FromBody] Spells spellDetailUpdate)
        {

            string spellName = spellDetailUpdate.SpellName;

            short spellLevel = spellDetailUpdate.SpellLevel;

            string schoolOfMagic = spellDetailUpdate.SchoolOfMagic;

            string spellCastingTime = spellDetailUpdate.SpellCastingTime;

            bool ritual = spellDetailUpdate.Ritual;

            string spellRange = spellDetailUpdate.SpellRange;

            string spellComponents = spellDetailUpdate.SpellComponents;

            string spellDuration = spellDetailUpdate.SpellDuration;

            string spellDescription = spellDetailUpdate.SpellDescription;

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var spellToUpdate = context.Spells
                                       .FirstOrDefault(spell => spell.SpellName == spellName);
                    
                    spellToUpdate.SpellLevel = spellLevel;

                    spellToUpdate.SchoolOfMagic = schoolOfMagic;

                    spellToUpdate.SpellCastingTime = spellCastingTime;

                    spellToUpdate.Ritual = ritual;

                    spellToUpdate.SpellRange = spellRange;

                    spellToUpdate.SpellComponents = spellComponents;

                    spellToUpdate.SpellDuration = spellDuration;

                    spellToUpdate.SpellDescription = spellDescription;

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Spell details update failed, please try again.";
            }
            catch(Exception)
            {
                return "An unexpected error occurred. Please try again.";
            }

            return $"Item details for {spellName} updated successfully!";

        }
    }

}
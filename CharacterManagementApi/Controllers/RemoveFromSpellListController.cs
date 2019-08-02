using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RemoveFromSpellListController : ControllerBase
    {
        [HttpGet]

        public ActionResult<string> Get([FromQuery] string characterName, string spellName)
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var spellToRemove = context.CharacterSpells
                                        .FirstOrDefault(spell => spell.SpellName == spellName && spell.CharacterName == characterName);

                    context.CharacterSpells.Remove(spellToRemove);

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return $"Could not remove {spellName} from {characterName}'s inventory at this time. Please try again!";
            }
            catch(Exception)
            {
                return "An unexpected error occurred";
            }

            return $"{spellName} removed from {characterName}'s spelllist!";
        }
    }
}
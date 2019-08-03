using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;


namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DeleteSpellController : ControllerBase
    {
        [HttpGet]

        public ActionResult<string> GetAction([FromQuery] string spellName)
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var spellToDelete = context.Spells
                                        .FirstOrDefault(spell => spell.SpellName == spellName);

                    context.CharacterSpells.RemoveRange(context.CharacterSpells.Where(spell => spell.SpellName == spellName));

                    context.Spells.Remove(spellToDelete);

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return $"Could not delete {spellName} from the database at this time. Please try again!";
            }
            catch(Exception)
            {
                return "An unexpected error occurred";
            }

            return $"{spellName} deleted from the database entirely!";
        }
    }

}
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RemoveFromAllSpellListsController : ControllerBase
    {
        [HttpGet]

        public ActionResult<string> Get([FromQuery] string spellName)
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    context.CharacterSpells.RemoveRange(context.CharacterSpells.Where(spell => spell.SpellName == spellName));

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return $"Could not remove {spellName} from all spell lists at this time. Please try again!";
            }
            catch(Exception)
            {
                return $"An unexpected error occurred. Please try again!";
            }

            return $"{spellName} removed from all characters' spell lists!";
        }
    }
}
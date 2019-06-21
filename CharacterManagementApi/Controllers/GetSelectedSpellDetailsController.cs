using System;
using Microsoft.AspNetCore.Mvc;
using CharacterManagementApi.CharacterManagementDBModel;
using System.Linq;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSelectedSpellDetailsController : ControllerBase
    {
        
        // GET api/viewcharacterdropdown
        [HttpGet]
        public ActionResult<Spells> Get([FromQuery] string spellName)
        {
            try
            {
                using (var context = new CharacterManagementDBContext())
                {
                    var spellDetails = context.Spells
                                       .FirstOrDefault(spell => spell.SpellName == spellName);
                    
                    return spellDetails;
                }
            }
            catch(Exception)
            {
                return new Spells();
            }
        }
    }
}
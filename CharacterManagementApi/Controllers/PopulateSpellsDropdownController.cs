using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;
using System.Linq;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulateSpellsDropdownController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery] string characterName)
        {
            List<string> listOfSpellNames = new List<string>();

            using (var context = new CharacterManagementDBContext())
            {
                var characterSpellList = context.CharacterSpells
                                         .Where(spells => spells.CharacterName == characterName)
                                         .Select(spells => new {spells.SpellName});
                                        
                foreach (var spell in characterSpellList)
                {
                    listOfSpellNames.Add(spell.SpellName);
                }
            }

            return listOfSpellNames;
        }
    }
}
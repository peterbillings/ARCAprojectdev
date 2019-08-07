using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PopulateExistingSpellsDropDownController : ControllerBase
    {
        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> allSpells = new List<string>();

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var allExistingSpells = context.Spells
                                           .OrderBy(spell => spell.SpellName)
                                           .Select(spell => new {spell.SpellName});

                    foreach (var spell in allExistingSpells)
                    {
                        allSpells.Add(spell.SpellName);
                    }
                }
            }
            catch(Exception)
            {
                return allSpells.ToArray();
            }

            return allSpells.ToArray();
        }
    }
}
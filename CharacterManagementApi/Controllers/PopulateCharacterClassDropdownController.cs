using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulateCharacterClassDropdownController : ControllerBase
    {
        
        // GET api/populateCharacterClassDropdown
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> listOfCharacterClasses = new List<string>();

            using (var context = new CharacterManagementDBContext())
            {
                var allCharacterClasses = context.CharacterClass
                                        .OrderBy(classes => classes.CharacterClass1)
                                        .Select(classes => new {classes.CharacterClass1}); //??projection??
                                        
                
                foreach (var characterClass in allCharacterClasses)
                {
                    listOfCharacterClasses.Add(characterClass.CharacterClass1);
                }
            }

            return listOfCharacterClasses;
        }

    }
}
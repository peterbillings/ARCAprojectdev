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
    public class PopulateRaceDropdownController : ControllerBase
    {
        
        // GET api/populateracedropdown
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> listOfRaces = new List<string>();

            using (var context = new CharacterManagementDBContext())
            {
                var allRaces = context.Race
                                        .OrderBy(races => races.Race1)
                                        .Select(races => new {races.Race1}); //??projection??
                                        
                
                foreach (var race in allRaces)
                {
                    listOfRaces.Add(race.Race1);
                }
            }

            return listOfRaces;
        }

    }
}
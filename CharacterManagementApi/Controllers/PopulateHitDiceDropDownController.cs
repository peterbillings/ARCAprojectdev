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
    public class PopulateHitDiceDropdownController : ControllerBase
    {
        
        // GET api/populatehitdicedropdown
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> listOfHitDice = new List<string>();

            using (var context = new CharacterManagementDBContext())
            {
                var allHitDice = context.HitDice
                                        .OrderBy(hitdice => hitdice.HitDice1)
                                        .Select(hitdice => new {hitdice.HitDice1});
                                        

                foreach (var hitdice in allHitDice)
                {
                    listOfHitDice.Add(hitdice.HitDice1);
                }
            }

            return listOfHitDice;
        }
    }
}
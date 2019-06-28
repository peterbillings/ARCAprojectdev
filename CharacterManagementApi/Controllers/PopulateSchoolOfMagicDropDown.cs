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
    public class PopulateSchoolOfMagicDropdownController : ControllerBase
    {
        
        // GET api/populateschoolofmagicdropdown
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> listOfSchoolOfMagic = new List<string>();

            using (var context = new CharacterManagementDBContext())
            {
                var allSchoolsOfMagic = context.SchoolOfMagic
                                        .OrderBy(schoolofmagic => schoolofmagic.SchoolOfMagic1)
                                        .Select(schoolofmagic => new {schoolofmagic.SchoolOfMagic1});
                                        

                foreach (var schoolofmagic in allSchoolsOfMagic)
                {
                    listOfSchoolOfMagic.Add(schoolofmagic.SchoolOfMagic1);
                }
            }

            return listOfSchoolOfMagic;
        }
    }
}
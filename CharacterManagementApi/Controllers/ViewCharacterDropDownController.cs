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
    public class ViewCharacterDropDownController : ControllerBase
    {
        
        // GET api/viewcharacterdropdown
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> listOfCharacterNames = new List<string>();

            using (var context = new CharacterManagementDBContext())
            {
                var allCharacterNames = context.CharacterDetails
                                        .OrderBy(names => names.CharacterName)
                                        .Select(names => new {names.CharacterName}); //??projection??
                                        
                
                foreach (var name in allCharacterNames)
                {
                    listOfCharacterNames.Add(name.CharacterName);
                }
            }

            //return listOfCharacterNames.ToArray();
            return listOfCharacterNames;
        }

    }
}
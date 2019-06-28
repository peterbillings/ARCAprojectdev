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
    public class PopulateBackgroundDropdownController : ControllerBase
    {
        
        // GET api/populatebackgrounddropdown
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> listOfBackgrounds = new List<string>();

            using (var context = new CharacterManagementDBContext())
            {
                var allBackgrounds = context.Background
                                        .OrderBy(backgrounds => backgrounds.Background1)
                                        .Select(backgrounds => new {backgrounds.Background1}); //??projection??
                                        
                
                foreach (var background in allBackgrounds)
                {
                    listOfBackgrounds.Add(background.Background1);
                }
            }

            return listOfBackgrounds;
        }

    }
}
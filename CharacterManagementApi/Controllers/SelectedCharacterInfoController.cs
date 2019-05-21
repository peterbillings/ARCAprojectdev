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
    public class SelectedCharacterInfoController : ControllerBase
    {  
        // GET api/selectedcharacterinfo
        [HttpGet]
        public ActionResult<CharacterDetails> Get([FromQuery] string characterName)
        {

            using (var context = new CharacterManagementDBContext())
            {
                var selectedCharacterInfo = context.CharacterDetails
                                            .FirstOrDefault(details => details.CharacterName == characterName);

                return selectedCharacterInfo;
            }

            //return characterDetails;
        }
    }
}
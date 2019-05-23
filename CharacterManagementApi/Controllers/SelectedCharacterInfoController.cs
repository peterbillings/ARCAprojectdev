using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CharacterManagementApi.CharacterManagementDBModel;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

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
            try 
            {
                using (var context = new CharacterManagementDBContext())
                {
                    var selectedCharacterInfo = context.CharacterDetails
                                                .FirstOrDefault(details => details.CharacterName == characterName);

                    return selectedCharacterInfo;
                }
            }
            catch(DbException)
            {
                return new CharacterDetails(); //figure out a better way to handle this instead of sending a blank object
            }

        }
    }
}
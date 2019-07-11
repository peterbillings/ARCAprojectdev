using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CharacterManagementApi.CharacterManagementDBModel;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCharacterStatusController : ControllerBase
    {  
        // GET api/getcharacterstatus
        [HttpGet]
        public ActionResult<CharacterStatus> Get([FromQuery] string characterName)
        {
            try 
            {
                using (var context = new CharacterManagementDBContext())
                {
                    var selectedCharacterStatus = context.CharacterStatus
                                                .FirstOrDefault(status => status.CharacterName == characterName);

                    return selectedCharacterStatus;
                }
            }
            catch(DbException)
            {
                return new CharacterStatus();
            }
        }
    }
}
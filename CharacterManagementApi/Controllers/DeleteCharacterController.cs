using System;
using System.Linq;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCharacterController : ControllerBase
    {
        // GET api/deletecharacter
        [HttpGet]
        public ActionResult<string> Get([FromQuery] string characterName)
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var selectedCharacter = context.CharacterDetails
                                            .FirstOrDefault(details => details.CharacterName == characterName);

                    context.CharacterInventory.RemoveRange(context.CharacterInventory.Where(item => item.CharacterName == characterName));

                    context.CharacterSpells.RemoveRange(context.CharacterSpells.Where(spell => spell.CharacterName == characterName));

                    context.CharacterStatus.RemoveRange(context.CharacterStatus.Where(status => status.CharacterName == characterName));

                    context.CharacterDetails.Remove(selectedCharacter);

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return $"Deletion of {characterName} from database has failed.";
            }
            catch(DbException)
            {
                return "An unexpected error occurred, please try again.";
            }

            return $"{characterName} has been eradicated.";
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateInitiativeCurrentHpController : ControllerBase
    {

        // POST api/updateinitiativecurrenthp
        [HttpPost]
        public ActionResult<string> Post([FromBody] List<string> nameAndCurrentHp)
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {   
                    foreach (string nameAndHp in nameAndCurrentHp)
                    {
                        string[] updateInfo = nameAndHp.Split('_');

                        string name = updateInfo[0];

                        int hp = Convert.ToInt32(updateInfo[1]);

                        if (context.CharacterStatus.Any(status => status.CharacterName == name))
                        {
                            var selectedCharacterStatus = context.CharacterStatus
                                                        .FirstOrDefault(status => status.CharacterName == name);
                            
                            selectedCharacterStatus.CurrentHp = hp;
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "HP Update Failed! Try Again.";
            }
            catch(Exception)
            {
                return "An unexpected error occurred. Please try again.";
            }

            return "HP Updated Successfully!";
        }

    }
}
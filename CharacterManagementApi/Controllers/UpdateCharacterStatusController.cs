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

    public class UpdateCharacterStatusController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Post([FromBody] List<string> statusUpdateInfo)
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    foreach (string statusUpdate in statusUpdateInfo)
                    {
                        string[] statusValues = statusUpdate.Split('_');

                        string characterName = statusValues[0];

                        int currentHp = Convert.ToInt32(statusValues[1]);

                        int tempHp = Convert.ToInt32(statusValues[2]);

                        int gold = Convert.ToInt32(statusValues[3]);

                        int exhaustion = Convert.ToInt32(statusValues[4]);

                        string condition = statusValues[5];

                        var selectedCharacterStatus = context.CharacterStatus
                                                      .FirstOrDefault(status => status.CharacterName == characterName);
                            
                        selectedCharacterStatus.CurrentHp = currentHp;

                        selectedCharacterStatus.TempHp = tempHp;

                        selectedCharacterStatus.Gold = gold;

                        selectedCharacterStatus.Exhaustion = exhaustion;

                        selectedCharacterStatus.Condition = condition;
                    }

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Status update failed, please try again.";
            }
            catch(Exception)
            {
                return "An unexpected error occurred.  Please try again.";
            }

            return "Character Status(es) updated successfully!";
        }
    }
}
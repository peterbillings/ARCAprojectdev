using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DeleteCurrentQuestLogEntryController : ControllerBase
    {
        [HttpGet]

        public ActionResult<string> Get([FromQuery] int questLogId)
        {
            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var questLogEntryToDelete = context.QuestLog
                                                .FirstOrDefault(entry => entry.LogEntryId == questLogId);

                    context.QuestLog.Remove(questLogEntryToDelete);

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Could not delete the quest log entry at this time. Please try again!";
            }
            catch(Exception)
            {
                return "An unexpected errro occurred. Please try again!";
            }

            return "Quest log entry deleted!";
        }
    }
}
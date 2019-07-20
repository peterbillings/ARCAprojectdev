using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UpdateCurrentQuestLogEntryController : ControllerBase
    {
        [HttpPost]

        public ActionResult<string> Post([FromBody] string questLogUpdate)
        {

            string[] logUpdateInfo = questLogUpdate.Split('_');

            int currentLogEntryId = Convert.ToInt32(logUpdateInfo[0]);

            string logEntryTextUpdate = logUpdateInfo[1];

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var logEntryToUpdate = context.QuestLog
                                           .FirstOrDefault(logEntry => logEntry.LogEntryId == currentLogEntryId);

                    logEntryToUpdate.EntryText = logEntryTextUpdate;

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Quest log entry update failed. Please try again.";
            }
            catch(Exception)
            {
                return "An unexpected error occurred.  Please try again.";
            }

            return "Quest log entry updated successfully!";
        }
    }
}
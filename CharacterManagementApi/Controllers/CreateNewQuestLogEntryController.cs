using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CreateNewQuestLogEntryController : ControllerBase
    {
        [HttpGet]

        public ActionResult<QuestLog> Get()
        {
            var newLogEntry = new QuestLog();

            var error = new QuestLog();

            error.LogEntryId = 0;

            newLogEntry.EntryDate = DateTime.Now;

            newLogEntry.EntryText = "New Entry";

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    context.QuestLog.Add(newLogEntry);

                    context.SaveChanges();

                    var latestLogEntryId = context.QuestLog.Max(id => id.LogEntryId);

                    var latestLogEntry = context.QuestLog
                                         .FirstOrDefault(logEntry => logEntry.LogEntryId == latestLogEntryId);

                    return latestLogEntry;
                }
            }
            catch(DbUpdateException)
            {
                return error;
            }
            catch(Exception)
            {
                return error;
            } 
        }
    }
}
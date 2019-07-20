using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetLatestQuestLogEntryController : ControllerBase
    {
        [HttpGet]

        public ActionResult<QuestLog> Get()
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var latestLogEntryId = context.QuestLog.Max(id => id.LogEntryId);

                    var latestLogEntry = context.QuestLog
                                         .FirstOrDefault(logEntry => logEntry.LogEntryId == latestLogEntryId);

                    return latestLogEntry;
                }
            }
            catch(Exception)
            {
                var error = new QuestLog();

                error.EntryText = "No log entries have been created.<br> Click -New Entry- to start.";

                return error;
            }
            
        }
    }
}
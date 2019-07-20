using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetAdjacentQuestLogEntryController : ControllerBase
    {
        [HttpGet]

        public ActionResult<QuestLog> Get([FromQuery] int currentId, string nextOrPrevious)
        {
            int idIncrement = 0;

            if (nextOrPrevious.Equals("next"))
            {
                idIncrement = 1;
            }

            if (nextOrPrevious.Equals("previous"))
            {
                idIncrement = -1;
            }

            int adjacentLogEntryId = currentId + idIncrement;

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    if (context.QuestLog.Any(logEntry => logEntry.LogEntryId == adjacentLogEntryId))
                    {
                        var adjacentLogEntry = context.QuestLog
                                               .FirstOrDefault(logEntry => logEntry.LogEntryId == adjacentLogEntryId);
                        
                        return adjacentLogEntry;
                    }
                    else
                    {
                        var noEntry = new QuestLog();

                        noEntry.LogEntryId = 0;

                        return noEntry;
                    }
                }
            }
            catch(Exception)
            {
                return new QuestLog();
            }
        }
    }
}
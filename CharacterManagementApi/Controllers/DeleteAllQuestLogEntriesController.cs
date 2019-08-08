using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DeleteAllQuestLogEntriesController : ControllerBase
    {
        [HttpGet]

        public ActionResult<string> Get()
        {   
            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    context.QuestLog.RemoveRange(context.QuestLog);

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Could not delete all log entries at this time. Please try again!";
            }
            catch(Exception)
            {
                return "An unexpected error occurred. Please try again!";
            }

            return "All quest log entries deleted successfully!";
        }
    }
}
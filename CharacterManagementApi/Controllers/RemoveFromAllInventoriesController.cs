using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RemoveFromAllInventoriesController : ControllerBase
    {
        [HttpGet]

        public ActionResult<string> Get([FromQuery] string itemName)
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    context.CharacterInventory.RemoveRange(context.CharacterInventory.Where(item => item.ItemName == itemName));

                    context.SaveChanges();

                    // RemoveRange(db.ProRel.Where(c => c.ProjectId == Project_id)) --removerange example
                }
            }
            catch(DbUpdateException)
            {
                return $"Could not remove {itemName} from all inventories at this time. Please try again!";
            }
            catch(Exception)
            {
                return $"An unexpected error occurred. Please try again!";
            }
            return $"{itemName} removed from all characters' inventories";
        }
    }
}
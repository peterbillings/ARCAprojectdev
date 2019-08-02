using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DeleteItemController : ControllerBase
    {
        [HttpGet]

        public ActionResult<string> Get([FromQuery] string itemName)
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {

                    var itemToDelete = context.Items
                                       .FirstOrDefault(item => item.ItemName == itemName);

                    context.CharacterInventory.RemoveRange(context.CharacterInventory.Where(item => item.ItemName == itemName));
                    
                    context.Items.Remove(itemToDelete);

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return $"Could not delete {itemName} from the database at this time. Please try again!";
            }
            catch(Exception)
            {
                return "An unexpected error occurred. Please try again!";
            }

            return $"{itemName} deleted from the database!";
        }
    }
}
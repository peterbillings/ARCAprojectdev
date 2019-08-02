using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RemoveFromInventoryController : ControllerBase
    {
        [HttpGet]

        public ActionResult<string> Get([FromQuery] string characterName, string itemName)
        {

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var itemToRemove = context.CharacterInventory
                                       .FirstOrDefault(item => item.CharacterName == characterName && item.ItemName == itemName);

                    context.CharacterInventory.Remove(itemToRemove);

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return $"Could not remove {itemName} from {characterName}'s invetory. Please try again!";
            }
            catch(Exception)
            {
                return "An unexpected error occurred. Please try again!";
            }

            return $"{itemName} removed from {characterName}'s inventory!";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;
using CharacterManagementApi.HttpRequestDataClasses;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateInventoryController : ControllerBase
    {
        
        [HttpPost]
        public ActionResult<string> Post([FromBody] InventoryUpdateInfo inventoryUpdate)
        {
            Items updateItem = new Items();

            updateItem.ItemName = inventoryUpdate.ItemName;
            updateItem.ItemDescription = inventoryUpdate.ItemDescription;
            updateItem.ItemValue = inventoryUpdate.ItemValue;

            CharacterInventory inventoryToUpdate = new CharacterInventory();

            inventoryToUpdate.CharacterName = inventoryUpdate.CharacterName;
            inventoryToUpdate.ItemName = inventoryUpdate.ItemName;
            inventoryToUpdate.ItemQuantity = inventoryUpdate.ItemQuantity;


            try
            {
                using (var context = new CharacterManagementDBContext())
                {
                    if (! context.Items.Any(item => item.ItemName == updateItem.ItemName))
                    {
                        context.Items.Add(updateItem);
                    }

                    if (! context.CharacterInventory.Any(inventory => (inventory.CharacterName == inventoryToUpdate.CharacterName &&
                                                                       inventory.ItemName == inventoryToUpdate.ItemName)))
                    {
                        context.CharacterInventory.Add(inventoryToUpdate);
                    }
                    else
                    {
                        var characterInventoryToUpdate = context.CharacterInventory
                                                         .FirstOrDefault(inventory => (inventory.CharacterName == inventoryToUpdate.CharacterName &&
                                                                                       inventory.ItemName == inventoryToUpdate.ItemName));

                        var quantity = characterInventoryToUpdate.ItemQuantity;

                        quantity += inventoryToUpdate.ItemQuantity;
                    }

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Inventory could not be updated. Please try again.";
            }
            catch(Exception)
            {
                return "Inventory update failed.";
            }

            return $"{inventoryUpdate.CharacterName}'s inventory updated successfully!";
        }
    }
}
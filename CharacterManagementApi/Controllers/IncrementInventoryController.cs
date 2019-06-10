using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncrementInventoryController : ControllerBase
    {
        
        // GET api/viewcharacterdropdown
        [HttpGet]
        public ActionResult<int> Get([FromQuery] string characterName, string itemName, int changeInQuantity)
        {
             try 
            {
                using (var context = new CharacterManagementDBContext())
                {
                    var selectedInventory = context.CharacterInventory
                                            .FirstOrDefault(inventory => inventory.CharacterName == characterName &&
                                                                         inventory.ItemName == itemName);
                    
                    var currentQuantity = selectedInventory.ItemQuantity;

                    if ( ! (currentQuantity == 0 && changeInQuantity == -1))
                    {

                        selectedInventory.ItemQuantity = currentQuantity + changeInQuantity;

                        context.SaveChanges();
                    }

                    return selectedInventory.ItemQuantity;
                }
            }
            catch(DbException)
            {
                return -1;
            }
            catch(Exception)
            {
                return -1;
            }
        }

    }
}
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;
using CharacterManagementApi.HttpRequestDataClasses;
using System.Linq;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSelectedItemDetailsController : ControllerBase
    {
        
        // GET api/viewcharacterdropdown
        [HttpGet]
        public ActionResult<SelectedItemDetails> Get([FromQuery] string characterName, string itemName)
        {
            SelectedItemDetails itemDetails = new SelectedItemDetails();
            
            using (var context = new CharacterManagementDBContext())
            {
                var details = context.Items
                              .FirstOrDefault(item => item.ItemName == itemName);
                
                var quantity = context.CharacterInventory
                               .FirstOrDefault(inventory => inventory.CharacterName == characterName &&
                                                            inventory.ItemName == itemName)
                               .ItemQuantity;

                itemDetails.ItemName = details.ItemName;

                itemDetails.ItemValue = details.ItemValue;

                itemDetails.ItemDescription = details.ItemDescription;

                itemDetails.ItemQuantity = quantity;
            }

            return itemDetails;
        }
    }
}
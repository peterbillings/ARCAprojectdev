using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UpdateItemDetailsController : ControllerBase
    {
        [HttpPost]

        public ActionResult<string> Post([FromBody] Items itemDetailUpdate)
        {

            string itemNameUpdate = itemDetailUpdate.ItemName;

            string itemDescriptionUpdate = itemDetailUpdate.ItemDescription;

            int itemValueUpdate = Convert.ToInt32(itemDetailUpdate.ItemValue);

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var itemToUpdate = context.Items
                                       .FirstOrDefault(item => item.ItemName == itemNameUpdate);
                    
                    itemToUpdate.ItemValue = itemValueUpdate;

                    itemToUpdate.ItemDescription = itemDescriptionUpdate;

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Item details update failed, please try again.";
            }
            catch(Exception)
            {
                return "An unexpected error occurred. Please try again.";
            }

            return $"Item details for {itemNameUpdate} updated successfully!";

        }
    }

}
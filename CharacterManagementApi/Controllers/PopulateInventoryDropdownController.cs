using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;
using System.Linq;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulateInventoryDropdownController : ControllerBase
    {
        
        // GET api/viewcharacterdropdown
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery] string characterName)
        {
            List<string> listOfCharacterNames = new List<string>();

            using (var context = new CharacterManagementDBContext())
            {
                var characterInventory = context.CharacterInventory
                                         .Where(items => items.CharacterName == characterName)
                                         .Select(items => new {items.ItemName});
                                        
                foreach (var item in characterInventory)
                {
                    listOfCharacterNames.Add(item.ItemName);
                }
            }

            return listOfCharacterNames;
        }
    }
}
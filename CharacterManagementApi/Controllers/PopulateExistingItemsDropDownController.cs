using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PopulateExistingItemsDropDownController : ControllerBase
    {
        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> allItems = new List<string>();

            try
            {
                using(var context = new CharacterManagementDBContext())
                {
                    var allExistingItems = context.Items
                                           .OrderBy(item => item.ItemName)
                                           .Select(item => new {item.ItemName});

                    foreach (var item in allExistingItems)
                    {
                        allItems.Add(item.ItemName);
                    }
                }
            }
            catch(Exception)
            {
                return allItems.ToArray();
            }

            return allItems.ToArray();
        }
    }
}
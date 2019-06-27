using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CharacterManagementApi.CharacterManagementDBModel;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCurrentValueOfSelectedAttributeController : ControllerBase
    {  
        // GET api/selectedcharacterinfo
        [HttpGet]
        public ActionResult<string> Get([FromQuery] string characterName, string characterAttribute)
        {

            // REFLECTION: Pass a string as a property name to a PropertyInfo for any type
            // then get the value of that property for any object of that type.

            try 
            {
                using (var context = new CharacterManagementDBContext())
                {
                    var selectedCharacter = context.CharacterDetails
                                            .FirstOrDefault(name => name.CharacterName == characterName);

                    PropertyInfo selectedAttribute = selectedCharacter.GetType().GetProperty(characterAttribute); 
                    
                    return selectedAttribute.GetValue(selectedCharacter).ToString();
                }
            }
            catch(DbException)
            {
                return "Unable to retrieve attribute value";
            }
            catch(Exception)
            {
                return "Unable to retrieve attribute value";
            }

        }
    }
}
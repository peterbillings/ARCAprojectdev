using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;
using CharacterManagementApi.HttpRequestDataClasses;
using System.Reflection;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCharacterInfoController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Post([FromBody] CharacterUpdateInfoWrapper updateInfoWrapper)
        {

            CharacterUpdateInfoParser updateInfo = new CharacterUpdateInfoParser(updateInfoWrapper);

            updateInfo.ParseUpdateInfo();

            try
            {
                using (var context = new CharacterManagementDBContext())
                {

                    for(int i = 0; i < updateInfo.UpdateNames.Count; i++)
                    {

                        var characterToUpdate = context.CharacterDetails
                                                .FirstOrDefault(details => details.CharacterName == updateInfo.UpdateNames.ElementAt(i));

                        if (characterToUpdate != null)
                        {

                            PropertyInfo attributeToUpdate = characterToUpdate.GetType().GetProperty(updateInfo.UpdateAttributes.ElementAt(i));

                            attributeToUpdate.SetValue(characterToUpdate, Convert.ChangeType(updateInfo.UpdateNewValues.ElementAt(i), attributeToUpdate.PropertyType), null);
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Unable to connect to database please try again.";
            }
            catch(Exception)
            {
                return "Character update failed due to unexpected error.";
            }

            return "Character information updated successfully!";

            // return updateInfoWrapper.DynamicUpdateInfo;
        }

    }
}
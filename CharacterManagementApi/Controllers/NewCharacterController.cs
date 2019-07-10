using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewCharacterController : ControllerBase
    {
        // dotnet CLI commands for db first model scaffolding
        // dotnet ef dbcontext scaffold "Server=LAPTOP-F2RUMMJU\SQLEXPRESS;Database=CharacterManagementDB;Trusted_Connection=True;MultipleActiveResultSets=True" Microsoft.EntityFrameworkCore.SqlServer -o CharacterManagementDBModel -c "CharacterManagementDBContext"

        // dotnet CLI commands for adding ef core packages
        // dotnet add package Microsoft.EntityFrameworkCore --version 2.2.4
        // dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 2.2.4
        // dotnet add package Microsoft.EntityFrameworkCore.Tools --version 2.2.4
        // dotnet add package Microsoft.EntityFrameworkCore.Design --version 2.2.4

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] CharacterDetails newCharacter)
        {

            CharacterStatus newStatus = new CharacterStatus();

            newStatus.CharacterName = newCharacter.CharacterName;

            newStatus.CurrentHp = newCharacter.MaxHp;

            try
            {
                using (var context = new CharacterManagementDBContext())
                {
                    context.CharacterDetails.Add(newCharacter);
                    context.SaveChanges();

                    context.CharacterStatus.Add(newStatus);
                    context.SaveChanges();
                }
            }
            catch(DbUpdateException)
            {
                return "Character could not be added to the database. Please try again.";
            }
            catch(Exception)
            {
                return "Character addition failed.";
            }

            return $"{newCharacter.CharacterName} added successfully!";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] NewCharacterFormData newCharacter)
        {
            return "";
        }

    }
}

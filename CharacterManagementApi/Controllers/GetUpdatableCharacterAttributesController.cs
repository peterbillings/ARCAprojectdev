using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharacterManagementApi.CharacterManagementDBModel;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUpdatableCharacterAttributesController : ControllerBase
    {
        
        // GET api/viewcharacterdropdown
        [HttpGet]
        public ActionResult<CharacterDetails> Get()
        {
            return new CharacterDetails();
        }

    }
}
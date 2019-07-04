using System;
using CharacterManagementApi.HttpRequestDataClasses;
using Microsoft.AspNetCore.Mvc;

namespace CharacterManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollTheDiceController : ControllerBase
    {  
        [HttpGet]
        public ActionResult<int> Get([FromQuery] int totalDice, int numberOfSides, int modifier )
        {
            DiceRollGenerator diceRoller = new DiceRollGenerator(totalDice, numberOfSides, modifier);

            int rollResult = diceRoller.RollDice();

            return rollResult;
        }
    }
}
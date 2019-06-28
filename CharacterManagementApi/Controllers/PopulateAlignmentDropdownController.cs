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
    public class PopulateAlignmentDropdownController : ControllerBase
    {
        
        // GET api/populatealignmentdropdown
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> listOfAlignments = new List<string>();

            using (var context = new CharacterManagementDBContext())
            {
                var allAlignments = context.Alignment
                                        .OrderBy(alignments => alignments.Alignment1)
                                        .Select(alignments => new {alignments.Alignment1});
                                        

                foreach (var alignment in allAlignments)
                {
                    listOfAlignments.Add(alignment.Alignment1);
                }
            }

            return listOfAlignments;
        }
    }
}
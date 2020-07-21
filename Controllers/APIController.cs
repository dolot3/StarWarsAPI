using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

//Question from the user story:  It wasn't clear where the data was supposed to come from i.e. database, etc.
namespace StarWarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
       
        [HttpGet("{numPersons}")]
        public IActionResult Get(int numPersons)
        {
            List<string> theList = new List<string>();

            try
            {
                for (int i = 1; i <= numPersons; i++)
                {
                    theList.Add("Person " + i.ToString());
                }

                var items = new { items = theList.ToArray() };

                return new JsonResult(Newtonsoft.Json.JsonConvert.SerializeObject(items));
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
            

        }

    }
}

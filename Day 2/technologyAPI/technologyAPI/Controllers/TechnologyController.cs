using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace technologyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {

        #region Data
        static List<string> techList = new List<string>() 
        {
            "ASP.Net MVC",
            "ASP.Net WebAPI",
            "ASP.Net Core", 
            "Angular", 
            "React", 
            "Node",
            "Azure" 
        };
        #endregion

        #region Get methods
        [HttpGet]
        [Route("/technology/list")]
        public IActionResult GetAllTechlist()
        {
            return Ok(techList);
        }
        [HttpGet]
        [Route("/technology/index/{idx}")]
        public IActionResult GetTechByIndex(int idx)
        {
            if (idx > techList.Count)
            {
                return NotFound("Sorry please choose lower index");
            }
            return Ok(techList[idx]);
        }
        [HttpGet]
        [Route("/technology/total")]
        public IActionResult GetTotalTechnologies()
        {
            return Ok(techList.Count);
        }
        [HttpGet]
        [Route("/technology/search/{characters}")]
        public IActionResult SearchTechnology(string characters)
        {
            var tech = techList.FindAll(c => c.StartsWith(characters));
            return Ok(tech);
        }
        #endregion

        #region Post, Put and Delete

        [HttpPost]
        [Route("/technology/add/{techName}")]
       public IActionResult AddNewTechnology(string techName)
       {
         techList.Add(techName);
         return Created("", "Technolgy Added to list");
       }
        [HttpDelete]
        [Route("/technology/delete/{idx}")]
        public IActionResult DeleteTechnolgy(int idx)
        {
            techList.RemoveAt(idx);
            return Accepted("Deleted a technology");
        }
        [HttpPut]
        [Route("/technology/edit/{idx}/{newName}")]
        public IActionResult EditTechnologyName(int idx, string newName)
        {
            techList[idx] = newName;
            return Accepted("Technology name changed");
        }


        #endregion

    }
}







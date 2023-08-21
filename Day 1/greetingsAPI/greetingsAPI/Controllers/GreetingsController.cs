using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace greetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {

        [HttpGet]
        [Route("/greet")]
        public IActionResult GreetUser()
        {
            //webapi methods will return HttpStatus Code and HttpMessage
            //if everything is ok , send 200 status code - which is OK            
            return Ok("Hello and Welcome to WebAPI Development");
        }

        [HttpGet]
        [Route("/greet/{name}")]
        public IActionResult GreetUser(string name)
        {
            return Ok("Hello " + name);
        }

        [HttpGet]
        [Route("/product/list")]
        public IActionResult Productlist()
        {
            List<string> pList = new List<string>()
            {
                "Pepsi","Coke","Maggie","Iphone","Dell","Boat","Samsung"
            };
            return Ok(pList);
        }



    }
}

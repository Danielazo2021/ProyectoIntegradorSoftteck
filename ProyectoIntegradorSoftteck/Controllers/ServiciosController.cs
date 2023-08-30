using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoIntegradorSoftteck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
     
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("ok");
        }

     
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {

            return Ok("ok");
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok("ok");
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("ok");
        }
    }
}

using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurHeroController : ControllerBase
    {
        private readonly IOurHeroService _heroService;
        public OurHeroController(IOurHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            var heros=_heroService.GetAllHeros(isActive);
            return Ok(heros);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hero = _heroService.GetHeroById(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddUpdateOurHero heroObject)
        {
            var hero = _heroService.AddOurHero(heroObject);
            if (hero == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Super Hero Created Successfully!!!",
                id = hero!.Id,
            });
        }
        [HttpPut]
        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateOurHero heroObject)
        {
            var hero = _heroService.UpdateOurHero(id,heroObject);
            if (hero == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Super Hero Created Successfully!!!",
                id = hero!.Id,
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_heroService.DeleteHerosById(id))
            {
                return NotFound();
            }
            return Ok(
                new
                {
                    message = "Super Hero Deleted Successfully!!"
                }
                );
        }
    }
}

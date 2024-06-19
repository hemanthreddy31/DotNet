﻿using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OurHeroController : ControllerBase
    {
        private readonly IOurHeroService _heroService;
        public OurHeroController(IOurHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool? isActive = null)
        {
            var heros = await _heroService.GetAllHeros(isActive);
            return Ok(heros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hero = await _heroService.GetHeroById(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUpdateOurHero heroObject)
        {
            var hero = await _heroService.AddOurHero(heroObject);
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
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AddUpdateOurHero heroObject)
        {
            var hero = await _heroService.UpdateOurHero(id,heroObject);
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
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _heroService.DeleteHerosById(id))
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

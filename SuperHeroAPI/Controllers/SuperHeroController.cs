using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskMangerAPI.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskMangerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : Controller
    {

    private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero {Id=1, FirstName="Kent", LastName="Clark", Name="SuperMan", Place="new planet"},
            new SuperHero {Id=2, FirstName="Bruyce", LastName="James", Name="BatMan", Place="Gothan"}
        };

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        heroes.Add(hero);
        return Ok(heroes);
    }
    }
}


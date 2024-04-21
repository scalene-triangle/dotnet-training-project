using auto_mapper_training.Dtos;
using auto_mapper_training.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace automappertraining
{
    [Route("api/training/[controller]")]
    [ApiController]
    public class SuperHeroController: ControllerBase
    {
        private static List<SuperHero> _superHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York",
                DateAdded = new DateTime(2001, 8, 10),
                DateModifiedd = null
            },
            new SuperHero
            {
                Id = 1,
                Name = "Iron Man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Malibu",
                DateAdded = new DateTime(1970, 5, 29),
                DateModifiedd = null
            },
        };

        private readonly IMapper _mapper;

        public SuperHeroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //[HttpGet]
        //public ActionResult<IList<SuperHeroDto>> GetHeroes()
        //{
        //    return _superHeroes.Select(hero => new SuperHeroDto
        //    {
        //        Name = hero.Name,
        //        FirstName = hero.FirstName,
        //        LastName = hero.LastName,
        //        Place = hero.Place
        //    }).ToList();
        //}

        [HttpGet]
        public ActionResult<IList<SuperHero>> GetHeroes()
        {
            return Ok(_superHeroes.Select(superHero => _mapper.Map<SuperHeroDto>(superHero)));
        }

        [HttpPost]
        public ActionResult AddHero(SuperHeroDto superHeroDto)
        {
            var superHero = _mapper.Map<SuperHero>(superHeroDto);
            _superHeroes.Add(superHero);

            return Ok(_superHeroes.Select(superHero => _mapper.Map<SuperHeroDto>(superHero)));
        }
    }
}

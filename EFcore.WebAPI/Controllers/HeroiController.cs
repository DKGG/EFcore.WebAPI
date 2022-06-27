using EFcore.Domain;
using EFcore.repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFcore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        public readonly HeroiContexto _context;

        public HeroiController(HeroiContexto context)
        {
            _context = context;
        }

        // GET: api/<HeroiController>
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            var listHeroi = _context.Herois.Where(H => H.Nome.Contains(nome)).ToList();
           /*var listHeroi = (from heroi in _context.Herois where heroi.Nome.Contains(nome) select heroi).ToList();*/
            return Ok(listHeroi);
        }

        // GET api/<HeroiController>/5
        [HttpGet("Atualizar/{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            //var heroi = new Heroi { Nome = nameHero };

            //contexto.Herois.Add(heroi);
            var heroi = _context.Herois.Where(H => H.Id == 3).FirstOrDefault();
            heroi.Nome = "Homem Aranha";           
            //_context.Add(heroi);
            _context.SaveChanges();
            
            return Ok();
        }

        // GET api/<HeroiController>/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi {Nome = "Capitão América" },
                new Heroi {Nome = "Doutor Estranho" },
                new Heroi {Nome = "Pantera Negra" },
                new Heroi {Nome = "Viúva Negra"},
                new Heroi {Nome = "Hulk"},
                new Heroi {Nome = "Gavião Arqueiro"},
                new Heroi {Nome = "Capitã Marvel"});
            _context.SaveChanges();

            return Ok();
        }

        // POST api/<HeroiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HeroiController>/5
        [HttpGet("delete/{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois.
                Where(x => x.Id == id)
                .Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}

using EFcore.Domain;
using EFcore.repo;
using EFCore.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFcore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly HeroiContexto _context;

        public BatalhaController(HeroiContexto context)
        {
            _context = context;
        }
        // GET: api/<BatalhaController1>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // GET api/<BatalhaController1>/5
        [HttpGet("{id}",Name = "GetBatalha")]
        public ActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<BatalhaController1>
        [HttpPost]
        public ActionResult Post(Batalha model)
        {
            try
            {
                _context.Batalhas.Add(model);
                _context.SaveChanges();
                return Ok("Deu certo");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // PUT api/<BatalhaController1>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {
            try
            {
                if (_context.Batalhas.AsNoTracking().FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return Ok("Deu certo");
                }
                return Ok("Não encontrado!");

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // DELETE api/<BatalhaController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

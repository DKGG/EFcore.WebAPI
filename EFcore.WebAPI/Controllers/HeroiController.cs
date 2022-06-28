using EFcore.Domain;
using EFcore.repo;
using EFcore.Repo;
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
    public class HeroiController : ControllerBase
    {
       
        private readonly IEFCoreRepository _repo;

        public HeroiController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<HeroiController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var herois = await _repo.GetAllHerois(true);
                return Ok(herois);
                
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
           
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}", Name = "GetHeroi")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var herois = await _repo.GetHeroiById(id, true);
                return Ok(herois);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // POST api/<HeroiController>
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangeAsync())
                {
                    return Ok("Deu certo");
                }
                return BadRequest("Não salvou");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Heroi model)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if(await _repo.GetHeroiById(id) != null)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Deu certo");
                    }
                }               
                
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
            return BadRequest($"Não Salvo!");
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if(await _repo.GetBatalhaById(id) != null)
                {
                    _repo.Delete(heroi);
                    if(await _repo.SaveChangeAsync())
                    {
                        return Ok("Deu certo");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest($"Nâo deletado!");
        }
    }
}

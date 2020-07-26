using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;

namespace ApiAppCenar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatosController : ControllerBase
    {
        private readonly PlatosRepository _repository;

        public PlatosController(PlatosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlatosDTO>>> Get()
        {
            var list = await _repository.GetAllDto();

            if (list.Count == 0)
            {
                return NotFound();
            }

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Platos>> Get(int id)
        {
            var plato = await _repository.GetById(id);

            if (plato == null)
            {
                return NotFound();
            }

            return plato;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Platos plato)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(plato);

                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PlatosDTO plato)
        {
            var platos = await _repository.GetById(id);

            if (platos == null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                var response = await _repository.UpdatePlatoDto(id, plato);

                if (response)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return BadRequest();
        }
    }
}
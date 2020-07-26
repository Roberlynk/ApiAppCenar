using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataBase.Model;
using Repository.Repository;
using DTO;

namespace ApiAppCenar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly IngredientesRepository _repository;

        public IngredientesController(IngredientesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredientesDTO>>> Get()
        {
            var list = await _repository.GetAllDto();

            if (list.Count == 0)
            {
                return NotFound();
            }

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredientes>> Get(int id)
        {
            var ingrediente = await _repository.GetById(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return ingrediente;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ingredientes ingrediente)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(ingrediente);

                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, IngredientesDTO ingrediente)
        {
            var ingredientes = await _repository.GetById(id);

            if (ingredientes == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _repository.UpdateIngredienteDto(id, ingrediente);

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

        [HttpPatch]
        public async Task<ActionResult> Patch(int id, IngredientesDTO ingrediente)
        {
            var ingredientes = await _repository.GetById(id);

            if (ingredientes == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _repository.UpdateIngredienteDto(id, ingrediente);

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
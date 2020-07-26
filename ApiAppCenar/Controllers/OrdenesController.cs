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
    public class OrdenesController : ControllerBase
    {
        private readonly OrdenesRepository _repository;

        public OrdenesController(OrdenesRepository repository)
        {
            _repository = repository;   
        }

        [HttpGet]
        public async Task<ActionResult<List<OrdenesDTO>>> Get()
        {
            var list = await _repository.GetAllDto();

            if (list.Count == 0)
            {
                return NotFound();
            }

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenes>> Get(int id)
        {
            var orden = await _repository.GetById(id);

            if (orden == null)
            {
                return NotFound();
            }

            return orden;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ordenes orden)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(orden);

                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, OrdenesDTO orden)
        {
            var ordenes = await _repository.GetById(id);

            if (ordenes == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _repository.UpdateOrdenDto(id, orden);

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var orden = await _repository.GetById(id);

            if (orden == null)
            {
                return NotFound();
            }
            else
            {
                await _repository.DeleteOrdenes(id);

                return NoContent();
            }
        }
    }
}
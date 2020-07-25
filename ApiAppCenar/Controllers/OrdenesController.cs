using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataBase.Model;
using Repository.Repository;

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
        public async Task<ActionResult<List<Ordenes>>> Get()
        {
            var list = await _repository.GetAll();

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenes>> Get(int id)
        {
            var orden = await _repository.GetById(id);

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
        public async Task<ActionResult> Put(int id, Ordenes orden)
        {
            if (ModelState.IsValid)
            {
                var response = await _repository.UpdateOrden(id, orden);

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
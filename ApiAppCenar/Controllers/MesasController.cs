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
    public class MesasController : ControllerBase
    {
        private readonly MesasRepository _repository;

        public MesasController(MesasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mesas>>> Get()
        {
            var list = await _repository.GetAll();

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mesas>> Get(int id)
        {
            var mesa = await _repository.GetById(id);

            return mesa;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Mesas mesa)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(mesa);

                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Mesas mesa)
        {
            if (ModelState.IsValid)
            {
                var response = await _repository.UpdateMesa(id, mesa);

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
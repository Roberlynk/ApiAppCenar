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
    public class MesasController : ControllerBase
    {
        private readonly MesasRepository _repository;

        public MesasController(MesasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MesasDTO>>> Get()
        {
            var list = await _repository.GetAllDto();

            if (list.Count == 0)
            {
                return NotFound();
            }

            return list;
        }

        [HttpGet]
        [Route("GetTableOrden")]
        public async Task<ActionResult<List<OrdenesDTO>>> GetTableByStatus(int id)
        {
            var ordenesByMesa = await _repository.GetAllDtoByStatus(id);

            if (ordenesByMesa.Count == 0)
            {
                return NotFound();
            }

            return ordenesByMesa;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mesas>> Get(int id)
        {
            var mesa = await _repository.GetById(id);

            if (mesa == null)
            {
                return NotFound();
            }

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

        [HttpPost]
        [Route("CompleteTable")]
        public async Task<ActionResult> PostCompleteTable(int id)
        {
            var mesas = await _repository.GetById(id);

            if (mesas == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _repository.CompleteTable(id);

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

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, MesasDTO mesa)
        {
            var mesas = await _repository.GetById(id);

            if (mesas == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _repository.UpdateMesaDto(id, mesa);

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
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, string estado)
        {
            var mesas = await _repository.GetById(id);

            if (mesas == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _repository.ChangeStatus(id, estado);

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
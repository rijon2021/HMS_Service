using DotNet.ApplicationCore.Entities.HMS;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DotNet.Services.HMS.Services.Interfaces;
using DotNet.WebApi.DTOs;

namespace DotNet.WebApi.Controllers.HMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IService<Branch> _service;

        public BranchController(IService<Branch> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetById(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BranchDto _entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var _entity = new Branch { 
                BranchCode = _entityDto.BranchCode,
                BranchName = _entityDto.BranchName,
                Location = _entityDto.Location,
                Email = _entityDto.Email,
                ContactNumber = _entityDto.Phone,
                HostelId= _entityDto.HostelId,
            };
             var CreatedEntity=   _service.Add(_entity);
            var createdEntity = await _service.Add(_entity);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.BranchId }, createdEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Branch entity)
        {
            if (id != entity.BranchId)
                return BadRequest();

            _service.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }

}

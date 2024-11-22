using DotNet.ApplicationCore.Entities.HMS;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

using DotNet.ApplicationCore.Entities;
using Newtonsoft.Json;
using DotNet.Services.HMS.Services.Interfaces;
using DotNet.WebApi.DTOs;
using DotNet.ApplicationCore.DTOs.HMS;

namespace DotNet.WebApi.Controllers.HMS
{
    
    [ Route("api/[controller]"), ApiController]
    public class HostelController : ControllerBase
    {
        private readonly IService<Hostel> _service;

        public HostelController(IService<Hostel> service)
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
        public async Task<IActionResult> Create([FromBody] DTOs.HostelDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var _entity = new Hostel
            {
                HostelName = entityDto.HostelName,
                Address = entityDto.Address,
                ContactNumber = entityDto.ContactNumber,
                Email = entityDto.Email,
                Website = entityDto.Website,
                TotalBranches = entityDto.TotalBranches,
                EstablishedDate = entityDto.EstablishedDate,
                Description = entityDto.Description,
                Amenities = entityDto.Amenities, // Assuming List<string> can be mapped directly
                HostelManager = entityDto.HostelManager,
                CreatedDate = entityDto.CreatedDate,
                UpdatedDate = entityDto.UpdatedDate
            };
            var createdEntity = await _service.Add(_entity);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.HostelId }, createdEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Hostel entity)
        {
            if (id != entity.HostelId)
                return BadRequest();

            await _service.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await _service.Delete(id);
            return NoContent();
        }
    }

}

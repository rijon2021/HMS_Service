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
                CreatedBy=0,
                CreatedAt=DateTime.UtcNow
                
            };
            var createdEntity = await _service.Add(_entity);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.HostelId }, createdEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOs.HostelDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // Fetch the existing entity from the database
            var existingEntity = await _service.GetById(id);
            if (existingEntity == null)
                return NotFound(); // Handle the case where the entity does not exist
                                   // Update the properties of the existing entity
            existingEntity.HostelName = entityDto.HostelName;
            existingEntity.Address = entityDto.Address;
            existingEntity.ContactNumber = entityDto.ContactNumber;
            existingEntity.Email = entityDto.Email;
            existingEntity.Website = entityDto.Website;
            existingEntity.TotalBranches = entityDto.TotalBranches;
            existingEntity.EstablishedDate = entityDto.EstablishedDate;
            existingEntity.Description = entityDto.Description;
            existingEntity.Amenities = entityDto.Amenities; // Assuming List<string> is directly assignable
            existingEntity.HostelManager = entityDto.HostelManager;
            existingEntity.UpdatedBy = 0; // Replace with actual user ID or logic
            existingEntity.UpdatedAt = DateTime.UtcNow;

            // Call the service to save changes
            await _service.Update(existingEntity);
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

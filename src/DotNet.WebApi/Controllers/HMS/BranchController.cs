using DotNet.ApplicationCore.Entities.HMS;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DotNet.Services.HMS.Services.Interfaces;
using DotNet.WebApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace DotNet.WebApi.Controllers.HMS
{
    [Authorize, Route("api/[controller]"), ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IService<Branch> _service;
        private readonly IAuthUserService _userService;
        public BranchController(IService<Branch> service, IAuthUserService userService)
        {
            _service = service;
            _userService = userService;
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
                return NotFound(new { message = Messages.EntityNotFound });
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DTOs.BranchDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = _userService.GetUserId(HttpContext); // Use the middleware service to get User ID
            var _entity = new Branch
            {
                BranchName = entityDto.BranchName,
                Location = entityDto.Location,
                ContactNumber = entityDto.Phone,
                Email = entityDto.Email,
                HostelId=entityDto.HostelId,
                Amenities=entityDto.Amenities,
                CreatedBy = userId,
                CreatedAt = DateTime.UtcNow

            };
            var createdEntity = await _service.Add(_entity);
            //return CreatedAtAction(nameof(GetById), new { id = createdEntity.BranchId }, createdEntity);
            return Ok(new { message = Messages.CreationSuccessful, entity = createdEntity });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOs.BranchDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // Fetch the existing entity from the database
            var existingEntity = await _service.GetById(id);
            if (existingEntity == null)
                return NotFound(new { message = Messages.EntityNotFound }); // Handle the case where the entity does not exist
            var userId = _userService.GetUserId(HttpContext); // Use the middleware service to get User ID                                               // Update the properties of the existing entity
            existingEntity.HostelId = entityDto.HostelId;
            existingEntity.BranchName = entityDto.BranchName;
            existingEntity.BranchCode = entityDto.BranchCode;
            existingEntity.Location = entityDto.Location;
            existingEntity.ContactNumber = entityDto.Phone;
            existingEntity.Email = entityDto.Email;
            existingEntity.Amenities = entityDto.Amenities;
            existingEntity.UpdatedBy = userId; // Replace with actual user ID or logic
            existingEntity.UpdatedAt = DateTime.UtcNow;

            // Call the service to save changes
            await _service.Update(existingEntity);
            return Ok(new { message = Messages.UpdateSuccessful }); // 200 OK with message
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                //// Fetch the existing entity from the database
                //var existingEntity = await _service.GetById(id);
                //if (existingEntity == null)
                //    return NotFound(); 


                //existingEntity.IsDeleted = true; 
                //existingEntity.DeletedBy = 0;
                //existingEntity.DeletedAt = DateTime.UtcNow;

                //// Call the service to save changes
                //await _service.Update(existingEntity);
                await _service.Delete(id);
                return Ok(new { message = Messages.DeletionSuccessful }); // 200 OK with message
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); // 404 Not Found
            }
        }
    }

}

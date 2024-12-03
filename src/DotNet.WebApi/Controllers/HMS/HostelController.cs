﻿using DotNet.ApplicationCore.Entities.HMS;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

using DotNet.ApplicationCore.Entities;
using Newtonsoft.Json;
using DotNet.Services.HMS.Services.Interfaces;
using DotNet.WebApi.DTOs;
using DotNet.ApplicationCore.DTOs.HMS;
using System.Collections.Generic;

namespace DotNet.WebApi.Controllers.HMS
{
    
    [Authorize, Route("api/[controller]"), ApiController]
    public class HostelController : ControllerBase
    {
        private readonly IService<Hostel> _service;
        private readonly IAuthUserService _userService;

        public HostelController(IService<Hostel> service, IAuthUserService userService)
        {
            _service = service;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = _userService.GetUserId(HttpContext); // Use the middleware service to get User ID
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
        public async Task<IActionResult> Create([FromBody] DTOs.HostelDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = _userService.GetUserId(HttpContext); // Use the middleware service to get User ID
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
               // Amenities = entityDto.Amenities, // Assuming List<string> can be mapped directly
                HostelManager = entityDto.HostelManager,
                Status = entityDto.Status,
                CreatedBy= userId,
                CreatedAt=DateTime.UtcNow
                
            };
            var createdEntity = await _service.Add(_entity);
            //return CreatedAtAction(nameof(GetById), new { id = createdEntity.HostelId }, createdEntity);
            return Ok(new { message = Messages.CreationSuccessful,entity= createdEntity });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOs.HostelDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // Fetch the existing entity from the database
            var existingEntity = await _service.GetById(id);
            if (existingEntity == null)
                return NotFound(new { message = Messages.EntityNotFound }); // Handle the case where the entity does not exist
            var userId = _userService.GetUserId(HttpContext); // Use the middleware service to get User ID
            // Update the properties of the existing entity
            existingEntity.HostelName = entityDto.HostelName;
            existingEntity.Address = entityDto.Address;
            existingEntity.ContactNumber = entityDto.ContactNumber;
            existingEntity.Email = entityDto.Email;
            existingEntity.Website = entityDto.Website;
            existingEntity.TotalBranches = entityDto.TotalBranches;
            existingEntity.EstablishedDate = entityDto.EstablishedDate;
            existingEntity.Description = entityDto.Description;
           // existingEntity.Amenities = entityDto.Amenities; // Assuming List<string> is directly assignable
            existingEntity.HostelManager = entityDto.HostelManager;
            existingEntity.Status = entityDto.Status;
            existingEntity.UpdatedBy = userId; // Replace with actual user ID or logic
            existingEntity.UpdatedAt = DateTime.UtcNow;

            // Call the service to save changes
            await _service.Update(existingEntity);
            return Ok(new { message = Messages.UpdateSuccessful }); // 200 OK with message
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try { 
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

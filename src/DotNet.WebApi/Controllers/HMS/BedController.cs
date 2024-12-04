﻿using DotNet.ApplicationCore.Entities.HMS;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

using Microsoft.AspNetCore.Authorization;
using DotNet.ApplicationCore.DTOs.HMS;
using DotNet.ApplicationCore.Entities;
using Newtonsoft.Json;
using DotNet.Services.HMS.Services.Interfaces;
using DotNet.WebApi.DTOs;
using System.Collections.Generic;

namespace DotNet.WebApi.Controllers.HMS
{
    [Authorize, Route("api/[controller]"), ApiController]
    public class BedController : Controller
    {
        private readonly IService<Bed> _service;
        private readonly IAuthUserService _userService;

        public BedController(IService<Bed> service, IAuthUserService userService)
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
                return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BedDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var _entity = new Bed
            {

                BedNumber = entityDto.BedNumber,
                RoomId = entityDto.RoomId,               
                Status = entityDto.Status,                
                CreatedAt = DateTime.UtcNow,
                CreatedBy = _userService.GetUserId(HttpContext)


            };
            var createdEntity = await _service.Add(_entity);
            //return CreatedAtAction(nameof(GetById), new { id = createdEntity.BranchId }, createdEntity);
            return Ok(new { message = Messages.CreationSuccessful, entity = createdEntity });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTOs.BedDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // Fetch the existing entity from the database
            var existingEntity = await _service.GetById(id);
            if (existingEntity == null)
                return NotFound(new { message = Messages.EntityNotFound }); // Handle the case where the entity does not exist
                                                                            // Update the properties of the existing entity
            existingEntity.BedNumber = entityDto.BedNumber;
            existingEntity.RoomId = entityDto.RoomId;
            existingEntity.IsAssigned = entityDto.IsAssigned;
            existingEntity.Status = entityDto.Status;
            existingEntity.UpdatedBy = _userService.GetUserId(HttpContext); // Replace with actual user ID or logic
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
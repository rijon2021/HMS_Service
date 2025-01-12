using DotNet.ApplicationCore.Entities.HMS;
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
using DotNet.Services.Services.Common;
using DotNet.Services.HMS.Services.Implementations;

namespace DotNet.WebApi.Controllers.HMS
{
    [Authorize, Route("api/[controller]"), ApiController]
    public class BedAssignController : Controller
    {
        private readonly IService<BedAssignHistory> _bedAssignHistoryService;
        private readonly IService<Bed> _bedService;
        private readonly IService<Member> _memberService;
        private readonly IAuthUserService _userService;

        public BedAssignController(IService<BedAssignHistory> bedAssignHistoryService,IService<Bed> bedService,
     IService<Member> memberService,
     IAuthUserService userService)
        {
            _bedAssignHistoryService = bedAssignHistoryService;
            _bedService = bedService;
            _memberService = memberService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // var entities = await _service.GetAll();           
            var entities = await _bedAssignHistoryService.FindAsync(
               null,      // No Filter 

                i=>i.Bed, i => i.Room, i => i.Branch, i => i.Member, i => i.AssignedByStaff, i => i.UnassignedByStaff);                // Include the related Room data
            return Ok(entities);
            //var entities = await _service.GetAll();
            //return Ok(entities);
        }

        //[HttpGet("History/Member/{id}")]
        //public async Task<IActionResult> GetAllByMember(int MemberId)
        //{
        //    // var entities = await _service.GetAll();           
        //    var entities = await _bedAssignHistoryService.FindAsync(
        //       i=>i.MemberId== MemberId,      // No Filter 
        //       i => i.Bed, i => i.Room, i => i.Branch, i => i.Member, i => i.AssignedByStaff, i => i.UnassignedByStaff);                // Include the related Room data
        //    return Ok(entities);
        //    //var entities = await _service.GetAll();
        //    //return Ok(entities);
        //}

        //[HttpGet("History/Bed/{id}")]
        //public async Task<IActionResult> GetAllByBed(int BedId)
        //{
        //    // var entities = await _service.GetAll();           
        //    var entities = await _bedAssignHistoryService.FindAsync(
        //       i => i.BedId == BedId,      // No Filter 
        //       i => i.Bed, i => i.Room, i => i.Branch, i => i.Member, i => i.AssignedByStaff, i => i.UnassignedByStaff);                // Include the related Room data
        //    return Ok(entities);
        //    //var entities = await _service.GetAll();
        //    //return Ok(entities);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _bedAssignHistoryService.GetById(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

     
        [HttpPost]
        public async Task<IActionResult> AssignBed([FromBody] BedAssignDto bedAssign)
        {
            if (bedAssign == null)
            {
                return BadRequest("Bed assignment details are required.");
            }

            var bed = await _bedService.GetById(bedAssign.BedId);
            if (bed == null)
            {
                return BadRequest("The specified bed does not exist.");
            }

            if (bed.IsAssigned)
            {
                return BadRequest("The bed is not available for assignment.");
            }

            var member = await _memberService.GetById(bedAssign.MemberId);
            if (member == null)
            {
                return BadRequest("The specified member does not exist.");
            }
            

            // Create a new bed assignment
            var bedAssignHistory = new BedAssignHistory
            {
                MemberId = bedAssign.MemberId,
                BedId = bedAssign.BedId,
                RoomId = bed.RoomId,
                BranchId = member.BranchId,
                AssignedBy = _userService.GetUserId(HttpContext),
                AssignedAt = DateTime.UtcNow,
                Status = 1
            };

            // Save the bed assignment history
            var createdEntity = await _bedAssignHistoryService.Add(bedAssignHistory);
            if (createdEntity!=null) {
                // Mark the bed as unavailable
                bed.IsAssigned = true;
                await _bedService.Update(bed);
                // Mark the bed as unavailable
                member.BedId = bed.BedId;
                await _memberService.Update(member);
            }    
            return Ok(new { message = "Successfully Bed Assigned", entity = createdEntity });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UnassignBed(int id)
        {
            var bedAssignHistory = await _bedAssignHistoryService.GetById(id);
            if (bedAssignHistory == null)
            {
                return NotFound($"Bed assignment with ID {id} not found.");
            }

            // Mark bed as available again
            var bed = await _bedService.GetById(bedAssignHistory.BedId);
            if (bed != null)
            {
                bed.IsAssigned = false;  // Make the bed available again
                await _bedService.Update(bed);
            }
            bedAssignHistory.Status = 0;  // Mark the assignment as inactive
            bedAssignHistory.UnassignedAt = DateTime.UtcNow;
            bedAssignHistory.UnassignedBy = _userService.GetUserId(HttpContext);
            await _bedAssignHistoryService.Update(bedAssignHistory);

            return Ok(new { message = "Successfully Bed Unassigned" }); // 200 OK with message
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
                await _bedAssignHistoryService.Delete(id);
                return Ok(new { message = Messages.DeletionSuccessful }); // 200 OK with message
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); // 404 Not Found
            }
        }
    }

}
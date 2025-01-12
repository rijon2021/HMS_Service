using DotNet.ApplicationCore.Entities.HMS;
using DotNet.Services.HMS.Repositories.Implementation;
using DotNet.Services.HMS.Repositories.Interfaces;
using DotNet.Services.HMS.Services.Interfaces;
using DotNet.Services.HMS.UnitOfWork;
using DotNet.Services.Repositories.Infrastructure;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.HMS.Services.Implementations
{
    public class MemberService : Service<Member>, IMemberService
    {
        public MemberService(UnitOfWork.IUnitOfWork unitOfWork, IRepository<Member> repository) : base(unitOfWork, repository)
        {
        }

        public Task<IEnumerable<object>> GetMembersDetails()
        {
         

           return Task.FromResult<IEnumerable<object>>(_repository.Query(b => b.Branch, b => b.Room,b=>b.Bed).Select(member => new
            {
                MemberId = member.MemberId,                
                FullName = member.FullName,
                BranchName = member.Branch.BranchName,
                RoomNumber = member.Room.RoomNumber,
                BedNumber = member.Bed.BedNumber,
                Address = member.Address,
                DateOfBirth = member.DateOfBirth
            })); // Pass the includes here
          
          

        }
    }

}

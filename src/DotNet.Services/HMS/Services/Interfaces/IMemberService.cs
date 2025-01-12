using DotNet.ApplicationCore.Entities.HMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.HMS.Services.Interfaces
{
    public interface IMemberService:IService<Member>
    {
         Task<IEnumerable<object>> GetMembersDetails();
    }
}

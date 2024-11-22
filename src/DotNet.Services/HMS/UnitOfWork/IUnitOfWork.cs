using DotNet.ApplicationCore.Entities.HMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.HMS.UnitOfWork
{
    public interface IUnitOfWork
    {
        //IRepository<Hostel> Hostels { get; }
        //IRepository<Branch> Branches { get; }
        //IRepository<Room> Rooms { get; }
        //IRepository<Bed> Beds { get; }
        Task<int> SaveChangesAsync();
    }
}

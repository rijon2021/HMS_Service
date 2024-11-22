using DotNet.ApplicationCore.Entities.HMS;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Common;
using DotNet.Services.Repositories.Interfaces.Common;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.HMS.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DotNetContext _context;
       

        //public IRepository<Hostel> Hostels { get; private set; }
        //public IRepository<Branch> Branches { get; private set; }
        //public IRepository<Room> Rooms { get; private set; }
        //public IRepository<Bed> Beds { get; private set; }

        public UnitOfWork(DotNetContext context)
        {
            _context = context;
            //Hostels = new Repository<Hostel>(_context);
            //Branches = new Repository<Branch>(_context);
            //Rooms = new Repository<Room>(_context);
            //Beds = new Repository<Bed>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        


    }
}
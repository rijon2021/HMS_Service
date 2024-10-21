using AutoMapper;
using DotNet.ApplicationCore.DTOs.VM;
using DotNet.ApplicationCore.Entities;

namespace DotNet.ApplicationCore
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRole, VMUserRole>();
        }
    }
}

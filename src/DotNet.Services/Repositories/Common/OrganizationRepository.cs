﻿using Microsoft.AspNetCore.Http;
using DotNet.ApplicationCore.Utils.Helper;
using DotNet.Infrastructure.Persistence.Contexts;
using AutoMapper;
using DotNet.ApplicationCore.Entities;
using DotNet.Services.Repositories.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Services.Repositories.Common
{
    //IGenericRepository<organization>,
    public class OrganizationRepository(
        DotNetContext context,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper
            ) : IOrganizationRepository
    {
        private readonly DotNetContext _context = context;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Organization>> GetAll()
        {
            var organizations = _context.Organizations.ToList();
            return await Task.FromResult(organizations);
        }
        public async Task<Organization?> GetByID(int id)
        {
            var result = _context.Organizations.SingleOrDefault(x => x.OrganizationID == id);
            return await Task.FromResult(result);
        }
        public async Task<Organization?> Add(Organization data)
        {
            var userId = await _httpContextAccessor!.HttpContext!.User.GetUserAutoIdFromClaimIdentity();
            data.CreatedBy = userId;
            data.CreatedDate = DateTime.Now;
            data.UpdatedBy = userId;
            data.UpdatedDate = DateTime.Now;
            _context.Organizations.Add(data);
            _context.SaveChanges();

            return await GetByID(data.OrganizationID);
        }
        public async Task<Organization?> Update(Organization organization)
        {
            var data = await GetByID(organization.OrganizationID);
            var userId = await _httpContextAccessor!.HttpContext!.User.GetUserAutoIdFromClaimIdentity();

            if (data == null)
            {   
                throw new Exception();
            }
            data.OrganizationCode = organization.OrganizationCode;
            data.OrganizationName = organization.OrganizationName;
            data.OrganizationNameBangla = organization.OrganizationNameBangla;
            data.OrganizationShortName = organization.OrganizationShortName;
            data.OrganizationType = organization.OrganizationType;
            data.ProductName = organization.ProductName;
            data.ProductCode = organization.ProductCode;
            data.Address = organization.Address;
            data.OrganizationLogo = organization.OrganizationLogo;
            data.ProductLogo = organization.ProductLogo;
            data.PublicURL = organization.PublicURL;
            data.PrivateURL = organization.PrivateURL;
            data.ContactPersonID = organization.ContactPersonID;
            data.MobileNo = organization.MobileNo;
            data.Email = organization.Email;
            data.Latitude = organization.Latitude;
            data.Longitude = organization.Longitude;
            data.OrganizationUserID = organization.OrganizationUserID;
            data.UpdatedBy = userId;
            data.UpdatedDate = DateTime.Now;

            _context.Organizations.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return await GetByID(data.OrganizationID);
        }      
        public async Task<bool> Delete(int organizationID)
        {
            var data = await GetByID(organizationID);
            if (data != null)
            {
                _context.Entry(data).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }



        
    }
}


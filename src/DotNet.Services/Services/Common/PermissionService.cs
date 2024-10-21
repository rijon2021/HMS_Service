using DotNet.ApplicationCore.DTOs;
using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;
using DotNet.Services.Repositories.Interfaces.Common;
using DotNet.Services.Services.Interfaces.Common;
using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.DTOs.Common;
using Newtonsoft.Json;

namespace DotNet.Services.Services.Common
{
    //GenericRepository<Users>,
    public class PermissionService(
        IPermissionRepository permissionRepository
            ) : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository = permissionRepository;
        readonly ResponseMessage rm = new();

        public async Task<IEnumerable<Permission>> GetAll()
        {
            return await _permissionRepository.GetAll();
        }
        public async Task<Permission?> GetByID(int id)
        {
            var response = await _permissionRepository.GetByID(id);
            return response;
        }
        public async Task<Permission?> Add(Permission permission)
        {
            var data = await _permissionRepository.Add(permission);
            return data;
        }
        public async Task<Permission> Update(Permission permission)
        {
            return await _permissionRepository.Update(permission);
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _permissionRepository.Delete(id);
            return response;
        }
        public List<PermissionDTO> MakeListWithChild(List<Permission> oList)
        {
            List<PermissionDTO> lstPermissionDTO = [];
            PermissionDTO? permissionDTO = new();

            if (oList != null && oList.Count > 0)
            {
                foreach (Permission permission in oList)
                {
                    var data = JsonConvert.SerializeObject(permission);
                    permissionDTO = JsonConvert.DeserializeObject<PermissionDTO>(data);
                    bool hasChild = oList.Any(x => x.ParentPermissionID == permission.PermissionID && x.PermissionType == PermissionType.Menu);
                    if (hasChild)
                    {
                        permissionDTO!.HasChild = true;
                    }
                    else
                    {
                        permissionDTO!.HasChild = false;
                    }
                    lstPermissionDTO.Add(permissionDTO);
                }
            }
            return lstPermissionDTO;
        }
        public async Task<IEnumerable<Permission>> UpdateOrder(List<Permission> oList)
        {
            return await _permissionRepository.UpdateOrder(oList);
        }
        public async Task<IEnumerable<Permission>> GetListByUserRoleID(int id)
        {
            return await _permissionRepository.GetListByUserRoleID(id);
        }
    }
}

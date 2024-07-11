
using IOT.Identity.Service.User.Dto;

namespace IOT.Identity.Repositories
{
    public interface IPermissionStateRepository
    {
        Task SaveUserPermissionsState(Guid userId, List<UserPermissionDto> permissions);
        Task<List<UserPermissionDto>> GetUserPermissionsState(Guid userId);
    }
}



using Building.Blocks.Core.Domain;
using Building.Blocks.Core.Domain.ValueObjects;

namespace IOT.Identity.Domain.Core
{
    public class RolePermission : AggregateRoot<Guid>
    {
        public Guid RoleId { get; private set; }
        public virtual Role Role { get; private set; }
        public Guid PermissionId { get; private set; }
        public DeleteLog DeleteLog { get; private set; }
        public CreateLog CreateLog { get; private set; }

        public RolePermission Of(Guid roleId, Guid permissionId,Guid currentUserId)
        {
            return new RolePermission(Id, roleId, permissionId, currentUserId);    
        }
        private RolePermission(Guid id,Guid roleId, Guid permissionId, Guid currentUser) {
        
            this.Id= id;
            this.RoleId = roleId;
            this.PermissionId = permissionId;
            this.DeleteLog = DeleteLog.Of(false);
            this.CreateLog = CreateLog.Of(currentUser);
        }
        private RolePermission() { }
    }
}

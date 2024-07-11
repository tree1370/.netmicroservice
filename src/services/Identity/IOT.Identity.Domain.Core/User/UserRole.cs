
using Building.Blocks.Core.Domain;
using Building.Blocks.Core.Domain.ValueObjects;

namespace IOT.Identity.Domain.Core
{
    public class UserRole : Entity<Guid>
    {
        public Guid RoleId { get; private set; }
        public Role Role { get; private set; }
        public Guid UserId { get; private set; }
        public virtual User User { get; private set; }
        public DeleteLog DeleteLog { get; private set; }
        public CreateLog CreateLog { get; private set; }
        public static UserRole Of(Guid roleId, Guid userId,Guid currentUserId)
        {
            return new UserRole(roleId, userId, currentUserId);
        }
        private UserRole() { }
        private UserRole(Guid roleId, Guid userId, Guid currentUser)
        {
            RoleId = roleId;
            UserId = userId;
            DeleteLog = DeleteLog.Of(false);
            CreateLog = CreateLog.Of(currentUser);
        }
    }
}

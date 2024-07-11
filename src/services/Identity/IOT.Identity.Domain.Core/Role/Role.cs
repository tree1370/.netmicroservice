using Building.Blocks.Core.Domain;
using Building.Blocks.Core.Domain.ValueObjects;

namespace IOT.Identity.Domain.Core
{
    public class Role : AggregateRoot<Guid>
    {
        public string RoleName { get;private set; }
        public bool IsActive { get;private set; }
        public TypeAccess TypeAccess { get; private set; }
        public DeleteLog DeleteLog { get; private set; } 
        public CreateLog CreateLog { get; private set; } 

        public Role Of(string roleName, bool isActive,TypeAccess typeAccess, Guid currentUser)
        {
            return new Role(Guid.NewGuid(), roleName, isActive, typeAccess,currentUser);
        }

        private Role(Guid id,string roleName , bool isActive, TypeAccess typeAccess, Guid currentUser) {
        
            this.Id = id;
            this.RoleName = roleName;
            this.IsActive = isActive;
            this.TypeAccess = typeAccess;
            this.DeleteLog = DeleteLog.Of(false);
            this.CreateLog = CreateLog.Of(currentUser);
        }
        private Role() { }


    }
}

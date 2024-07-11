using Building.Blocks.Core.Domain;
using Building.Blocks.Core.Domain.ValueObjects;

namespace IOT.Identity.Domain.Core
{
    public class Permission : AggregateRoot<Guid>
    {
        public string AppName { get; private set; }
        public string PermissionTitle { get; private set; }
        public string ActionName { get; private set; }
        public DeleteLog DeleteLog { get; private set; }
        public CreateLog CreateLog { get; private set; }

        private Permission Of(string title, string appName, string actionName, string permissiontitle, Guid currentUser)
        {
           return new Permission(Guid.NewGuid(),title, appName, actionName, permissiontitle,currentUser); 
        }

        private Permission(Guid id, string title, string appName, string actionName, string permissiontitle, Guid currentUser)
        {

            this.Id = id;
            this.AppName = appName;
            this.ActionName = actionName;
            this.PermissionTitle = permissiontitle;
            this.DeleteLog = DeleteLog.Of(false);
            this.CreateLog = CreateLog.Of(currentUser);
        }

        private Permission() { }
    }
}

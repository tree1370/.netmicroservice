using Building.Blocks.Core.Domain;
using Building.Blocks.Core.Domain.ValueObjects;

namespace IOT.Identity.Domain.Core
{
    public class UserRefreshToken : AggregateRoot<Guid>
    {
        public UserId UserId { get; set; }
        public virtual User User { get; set; }
        public string RefreshToken { get; private set; }
        //public int RefreshTokenTime { get; private set; }
        public DateTimeConvert CreateDate { get; private set; }
        public DateTimeConvert ExpireDate { get; private set; }
        public UserRefreshToken Of(Guid userId, string refreshToken, int refreshtokentTime, DateTime createDate,DateTime expireDate)
        {
            return new UserRefreshToken(Guid.NewGuid(),userId,refreshToken,refreshtokentTime,createDate, expireDate);
        }

        private UserRefreshToken(Guid id,Guid userId,string refreshToken,int refreshtokentTime,DateTime createDate,DateTime expireDate) {
        
            this.Id = id;
            this.UserId = new UserId(userId);
            this.RefreshToken = refreshToken;
            //this.RefreshTokenTime = refreshtokentTime;
            this.CreateDate = DateTimeConvert.Of(createDate);
            this.ExpireDate = DateTimeConvert.Of(expireDate);
        }

        private UserRefreshToken() { }

    }
}

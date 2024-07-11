using Building.Blocks.Core.Domain;
using Building.Blocks.Core.Domain.ValueObjects;
using IOT.Identity.Domain.Core;
using IOT.Identity.Service.User.ValueObject;

namespace IOT.Identity.Domain.Core
{
    public class User : AggregateRoot<UserId>
    {
        public string UserName { get; private set; }
        public Email Email { get; private set; }
        public UserNameInfo UserNameInfo { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; } = default!;
        public string Password { get; private set; }
        public string PasswordSalt { get; private set; }
        public DateTimeConvert RegisterDate { get; private set; }
        public DateTimeConvert LastLoginDate { get; private set; }
        public bool IsActive { get; private set; }
        public UserRefreshToken RefreshToken { get; private set; }
        //added by me
        public int AttempCount { get; private set; }
        public bool IsLock { get; private set; }
        public DateTimeConvert LockExpireDate { get; private set; }
        public LogInType LogInType { get; private set; }
        public long? LockReason_Id { get;private set; } = default!;
        public virtual ChangeLockReason? ChangeLockReason { get; private set; }
        public static User Of(string userName, string email, string firstname,string lastname, string countryCode,string phoneNumber,
            string password, string passwordSalt, DateTime registerDate, DateTime lastLoginDate, bool isActive,DateTime birthDate,
            Gender gender,int attempCount,bool isLock,DateTime expireDate,LogInType logInType, long? lockReason_Id)
        {
            var userId = new UserId(Guid.NewGuid());
            return new User(userName,userId,  email,  firstname,  lastname,  countryCode,  phoneNumber, password, passwordSalt, registerDate,
                lastLoginDate, isActive,birthDate,gender, attempCount, isLock, expireDate, logInType, lockReason_Id);
        }
        
        private User(string userName, UserId id, string email, string firstname, string lastname, string countryCode, string phoneNumber,
            string password, string passwordSalt, DateTime registerDate, DateTime lastLoginDate, bool isActive, DateTime birthDate,
            Gender gender, int attempCount, bool isLock, DateTime expireDate, LogInType logInType,long? lockReason_Id)
        {
            Id = id;
            UserName = userName;
            Email = Email.Of(email);
            UserNameInfo = UserNameInfo.Of(firstname,lastname,birthDate,gender);
            PhoneNumber =  PhoneNumber.Of(countryCode,phoneNumber);
            Password = password;
            PasswordSalt = passwordSalt;
            RegisterDate = DateTimeConvert.Of(registerDate);
            LastLoginDate = DateTimeConvert.Of(lastLoginDate);
            IsActive = isActive;
            AttempCount = attempCount;
            IsLock = isLock;
            LockExpireDate = DateTimeConvert.Of(expireDate);
            LogInType = logInType;
            LockReason_Id = lockReason_Id;
        }
        private User() { }
       
       
    }
}

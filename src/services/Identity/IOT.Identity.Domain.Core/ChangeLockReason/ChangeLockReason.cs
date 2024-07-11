using Building.Blocks.Core.Domain;
using Building.Blocks.Core.Domain.ValueObjects;
using Building.Blocks.Core.Exceptions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IOT.Identity.Domain.Core
{
    public class ChangeLockReason : AggregateRoot<long>
    {
        public string Message { get; private set; }
        public bool IsLockType { get; private set; }
        public DeleteLog DeleteLog { get; private set; }
        public CreateLog CreateLog { get; private set; }
        public static ChangeLockReason Of(string message,bool islockType,DateTime createDate,Guid currentUser)
        {
            if(string.IsNullOrWhiteSpace(message))
            {
                throw new InvalidNameException(nameof(message));
            }
            if(islockType == null) 
            {
                throw new InvalidNameException(nameof(islockType));
            }
            return new ChangeLockReason(message, islockType, createDate, currentUser);
        }
        private ChangeLockReason() { }
        private ChangeLockReason(string message, bool islockType, DateTime createDate, Guid currentUser)
        {
            Message = message;
            IsLockType = islockType;
            DeleteLog = DeleteLog.Of(false);
            CreateLog = CreateLog.Of(currentUser);
        }
    }
}

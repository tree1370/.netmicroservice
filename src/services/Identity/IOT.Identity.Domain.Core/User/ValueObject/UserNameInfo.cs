using Building.Blocks.Core.Domain.ValueObjects;
using Building.Blocks.Core.EFCore;
using Building.Blocks.Core.Exception;
using Building.Blocks.Core.Exceptions.Domain;
using IOT.Identity.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Service.User.ValueObject
{
    public class UserNameInfo : ValueObject<UserNameInfo>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName => FirstName + " " + LastName;
        public DateTimeConvert BirthDate { get; private set; }
        public Gender Gender { get; private set; }

        public static UserNameInfo Of(string firstName, string lastName,DateTime birhtDate,Gender gender)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length is > 100 or < 3)
            {
                throw new InvalidNameException(firstName);
            }

            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length is > 100 or < 3)
            {
                throw new InvalidNameException(lastName);
            }

            return new UserNameInfo 
            { 
                FirstName = firstName,
                LastName = lastName,
                BirthDate = DateTimeConvert.Of(birhtDate),
                Gender = gender
            };
        }




        protected override bool EqualsCore(UserNameInfo other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
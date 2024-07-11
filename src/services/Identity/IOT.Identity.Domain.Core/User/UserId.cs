using Building.Blocks.Core.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Domain.Core
{
    public sealed class UserId : StronglyTypedId<UserId>
    {
        public UserId(Guid value) : base(value)
        {
        }
    }
}

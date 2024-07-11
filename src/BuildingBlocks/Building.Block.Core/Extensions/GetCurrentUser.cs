using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Blocks.Core.Extensions
{
    public class GetCurrentUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public GetCurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public Guid GetUserId()
        {
            var aaa = httpContextAccessor.HttpContext.User.Claims;
            var UserId = Guid.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
            return UserId;
        }
    }
}

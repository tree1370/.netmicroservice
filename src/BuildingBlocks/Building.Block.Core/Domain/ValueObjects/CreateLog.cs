using Building.Blocks.Core.EFCore;
using Building.Blocks.Core.Exceptions.Domain;
using Building.Blocks.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Blocks.Core.Domain.ValueObjects;

public record CreateLog 
{
    #region DI
    private readonly GetCurrentUser getCurrentUser;

    public CreateLog(GetCurrentUser getCurrentUser)
    {
        this.getCurrentUser = getCurrentUser;
    }
    #endregion

    public Guid UserId {get;private set;}
    public DateTimeConvert Date { get; private set; }
    public static CreateLog Of(Guid currentUser)
    {
        return new CreateLog(DateTime.Now, currentUser);
    }
    private CreateLog() { }
    private CreateLog(DateTime date,Guid currentUser)
    {
        Date = DateTimeConvert.Of(date);
        UserId = currentUser;
    }
}

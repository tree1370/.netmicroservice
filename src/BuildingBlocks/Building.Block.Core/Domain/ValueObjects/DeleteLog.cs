using Building.Blocks.Core.EFCore;
using Building.Blocks.Core.Exceptions.Domain;
using Building.Blocks.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Blocks.Core.Domain.ValueObjects;

public record DeleteLog 
{
    #region DI
    private readonly GetCurrentUser getCurrentUser;

    public DeleteLog(GetCurrentUser getCurrentUser)
    {
        this.getCurrentUser = getCurrentUser;
    }
    #endregion
    public bool IsDeleted { get; private set; }
    public Guid UserId { get; private set; }
    public DateTimeConvert Date { get; private set; }
    public static DeleteLog Of(bool isDeleted)
    {
        return new DeleteLog(isDeleted);
    }
    private DeleteLog() { }
    private DeleteLog(bool isDeleted)
    {
        //first time always false
        IsDeleted = isDeleted;
        if (IsDeleted == true)
        {
            Date = DateTimeConvert.Of(DateTime.Now);
            UserId = getCurrentUser.GetUserId();
        }
    }
}

using Building.Blocks.Core.EFCore;
using Building.Blocks.Core.Exceptions.Domain;
using Building.Blocks.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Blocks.Core.Domain.ValueObjects;

public record DateTimeConvert
{
    public DateTime? Miladi { get; private set; }
    public string? Shamsi { get; private set; }
    public string? Ghamari { get; private set; }
    public static DateTimeConvert Of(DateTime date)
    {
        if (date == null)
        {
            throw new InvalidNameException(nameof(date));
        }
        var resultShmasi = date.ToShmasi();
        var resultGhamari = date.ToGhamari();

        return new DateTimeConvert(date, resultShmasi, resultGhamari);
    }
    private DateTimeConvert() { } //use for ef core
    private DateTimeConvert(DateTime date, string shamsi, string ghamari)
    {
        Miladi = date;
        Shamsi = shamsi;
        Ghamari = ghamari;
    }
}

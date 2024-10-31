using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Balta.Domain.SharedContext.Abstractions;

namespace Balta.Domain.Test.AccountContext.Projection
{
    public class DateTimeProvider : IDateTimeProvider
    {
        DateTime IDateTimeProvider.UtcNow => DateTime.UtcNow;
    }
}
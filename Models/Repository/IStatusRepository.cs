using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTN_API.Models
{
    public interface IStatusRepository
    {
        IEnumerable<Status> AllStatuses { get; }
    }
}

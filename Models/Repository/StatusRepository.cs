using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

namespace GTN_API.Models
{
    public class StatusRepository : IStatusRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public StatusRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<Status> AllStatuses
        {
            get
            {
                return _gtnDbContext.Statuses;
            }
        }
    }
}

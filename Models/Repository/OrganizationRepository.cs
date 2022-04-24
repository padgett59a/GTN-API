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
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly GtnDbContext _gtnDbContext;

        public OrganizationRepository(GtnDbContext gtnDbContext)
        {
            _gtnDbContext = gtnDbContext;
        }

        public IEnumerable<Organization> AllOrganizations
        {
            get
            {
                return _gtnDbContext.Organizations;
            }
        }
        public IEnumerable<Organization> AllOrganizationsShortNotes
        {
            get { return GTNCommonRepository.TableShortNotes<Organization>("Organizations", _gtnDbContext); }
        }

        public Organization GetOrganizationById(int orgID)
        {
            //may need to replace with paramaterized call to SP
            return _gtnDbContext.Organizations.Find(orgID);
        }
        public EntityEntry<Organization> AddOrg(Organization organization)
        {
            //may need to replace with paramaterized call to SP
            return _gtnDbContext.Organizations.Add(organization);
        }
        public EntityState UpdateOrg(Organization organization)
        {
            //may need to replace with paramaterized call to SP
            EntityEntry<Organization> retVal = _gtnDbContext.Organizations.Update(organization);
            EntityState updateState = retVal.State;
            _gtnDbContext.SaveChanges();
            return updateState;
        }
        public int AddOrgs(List<Organization> newOrgList)
        {
            int addCount = 0;
            foreach (Organization newOrg in newOrgList)
            {
                _gtnDbContext.Organizations.Add(newOrg);
                addCount++;
            }
            _gtnDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteOrgs(List<int> delOrgList)
        {
            int delCount = 0;
            Organization delOrg;
            foreach (int delorgID in delOrgList)
            {
                delOrg = _gtnDbContext.Organizations.Find(delorgID);
                _gtnDbContext.Organizations.Remove(delOrg);
            }
            try
            {
                _gtnDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains(GTN_SQL_ERR.REF_KEY_VIOLATION)) {
                    return GTN_SQL_ERR.RKEY_VIOL;
                }
                else
                {
                    return GTN_SQL_ERR.SQL_ERROR;
                }
            }
            delCount++;
            return delCount;
        }
    }
}

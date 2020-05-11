using SignLanguage.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignLanguage.EF.Repository
{
    class ActivityOnWebsiteRepository : IRepository<ActivityOnWebsite>
    {
        private readonly SignLanguageContex databaseContex;

        public ActivityOnWebsiteRepository(SignLanguageContex databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public void Add(ActivityOnWebsite entity)
        {
            databaseContex.ActivityOnWebsites.Add(entity);
        }

        public void Delete(ActivityOnWebsite entity)
        {
            databaseContex.ActivityOnWebsites.Remove(entity);
        }

        public ActivityOnWebsite GetDetail(Func<ActivityOnWebsite, bool> predicate)
        {
            return databaseContex.ActivityOnWebsites.FirstOrDefault(predicate);
        }

        public IEnumerable<ActivityOnWebsite> GetOverview(Func<ActivityOnWebsite, bool> predicate = null)
        {
            if (predicate != null)
            {
                return databaseContex.ActivityOnWebsites.Where(predicate).ToList();
            }
            else
            {
                return databaseContex.ActivityOnWebsites.ToList();
            }
        }

    }
}

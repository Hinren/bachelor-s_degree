using SignLanguage.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignLanguage.EF.Repository
{
    public class LogExceptionRepository : IRepository<LogException>
    {
        private SignLanguageContex databaseContex;

        public LogExceptionRepository(SignLanguageContex databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public void Add(LogException entity)
        {
            databaseContex.LogExceptions.Add(entity);
        }

        public void Delete(LogException entity)
        {
            databaseContex.LogExceptions.Remove(entity);
        }

        public LogException GetDetail(Func<LogException, bool> predicate)
        {
            return databaseContex.LogExceptions.FirstOrDefault(predicate);
        }

        public IEnumerable<LogException> GetOverview(Func<LogException, bool> predicate = null)
        {
            if (predicate != null)
            {
                return databaseContex.LogExceptions.Where(predicate).ToList();
            }
            else
            {
                return databaseContex.LogExceptions.ToList();
            }
        }
    }
}

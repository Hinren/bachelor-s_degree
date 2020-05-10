using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignLanguage.EF.Repository
{
    public class BadMeaningWordsRepository : IRepository<BadMeaningWords>
    {
        private readonly SignLanguageContex databaseContex;

        public BadMeaningWordsRepository(SignLanguageContex databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public void Add(BadMeaningWords entity)
        {
            databaseContex.BadMeaningWords.Add(entity);
        }

        public void Delete(BadMeaningWords entity)
        {
            databaseContex.BadMeaningWords.Remove(entity);
        }


        public BadMeaningWords GetDetail(Func<BadMeaningWords, bool> predicate)
        {
            return databaseContex.BadMeaningWords.FirstOrDefault(predicate);
        }

        public IEnumerable<BadMeaningWords> GetOverview(Func<BadMeaningWords, bool> predicate = null)
        {
            if (predicate != null)
            {
                return databaseContex.BadMeaningWords.Where(predicate).ToList();
            }
            else
            {
                return databaseContex.BadMeaningWords.ToList();
            }
        }

    }
}

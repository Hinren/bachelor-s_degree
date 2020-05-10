using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignLanguage.EF.Repository
{
    public class GoodMeaningWordsRepository :  IRepository<GoodMeaningWords>
    {
        private readonly SignLanguageContex databaseContex;

        public GoodMeaningWordsRepository(SignLanguageContex databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public void Add(GoodMeaningWords entity)
        {
            databaseContex.GoodMeaningWords.Add(entity);
        }

        public void Delete(GoodMeaningWords entity)
        {
            databaseContex.GoodMeaningWords.Remove(entity);
        }

        public GoodMeaningWords GetDetail(Func<GoodMeaningWords, bool> predicate)
        {
            return databaseContex.GoodMeaningWords.FirstOrDefault(predicate);
        }

        public IEnumerable<GoodMeaningWords> GetOverview(Func<GoodMeaningWords, bool> predicate = null)
        {
            if (predicate != null)
            {
                return databaseContex.GoodMeaningWords.Where(predicate).ToList();
            }
            else
            {
                return databaseContex.GoodMeaningWords.ToList();
            }
        }
    }
}

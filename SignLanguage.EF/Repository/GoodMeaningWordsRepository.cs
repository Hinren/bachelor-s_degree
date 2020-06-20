using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SignLanguage.EF.Paging;
using SignLanguage.Extension;

namespace SignLanguage.EF.Repository
{
    public class GoodMeaningWordsRepository : IGoodMeaningWordsRepository<GoodMeaningWords>
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
            foreach (var badMeaning in databaseContex.BadMeaningWords.ToList())
            {
                if (badMeaning.IdGoodMeaningWord == entity.IdGoodMeaningWord)
                {
                    var select = databaseContex.BadMeaningWords.ToList()
                        .Where(x => x.IdGoodMeaningWord == entity.IdGoodMeaningWord)
                        .FirstOrDefault();

                    databaseContex.BadMeaningWords.Remove(select);
                }
            }
        }

        public List<GoodMeaningWords> Get10RandomWordsThatHaveAtLeast3BadMeaning()
        {
            var goodMeaningWords = databaseContex.GoodMeaningWords.ToList();

            var badMeaningWords = databaseContex.BadMeaningWords.ToList();

            var selectedWordsToStartQuiz = new List<GoodMeaningWords>();
            foreach (var goodMeaningWord in goodMeaningWords)
            {
                if (badMeaningWords.Where(x => x.IdGoodMeaningWord == goodMeaningWord.IdGoodMeaningWord).Count() >= 3)
                {
                    selectedWordsToStartQuiz.Add(goodMeaningWord);
                }
            }
            return selectedWordsToStartQuiz.Shuffle(10).ToList();
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

        public PagingResult<GoodMeaningWords> GetPaged(int page, int pageSize)
        {
            var collection = databaseContex.GoodMeaningWords.ToList();

            var result = new PagingResult<GoodMeaningWords>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = collection.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = collection.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}

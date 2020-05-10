using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignLanguage.EF.Repository
{
    public class UsersScoreQuizRepository : IRepository<UsersScoreQuiz>
    {
        private readonly SignLanguageContex databaseContex;

        public UsersScoreQuizRepository(SignLanguageContex databaseContex)
        {
            this.databaseContex = databaseContex;
        }
        public void Add(UsersScoreQuiz entity)
        {
            databaseContex.UsersScoreQuiz.Add(entity);
        }

        public void Delete(UsersScoreQuiz entity)
        {
            databaseContex.UsersScoreQuiz.Remove(entity);
        }

        public UsersScoreQuiz GetDetail(Func<UsersScoreQuiz, bool> predicate)
        {
            return databaseContex.UsersScoreQuiz.FirstOrDefault(predicate);
        }

        public IEnumerable<UsersScoreQuiz> GetOverview(Func<UsersScoreQuiz, bool> predicate = null)
        {
            if (predicate != null)
            {
                return databaseContex.UsersScoreQuiz.Where(predicate).ToList();
            }
            else
            {
                return databaseContex.UsersScoreQuiz.ToList();
            }
        }
    }
}

using SignLanguage.EF.Models;
using SignLanguage.EF.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF
{
    public class UnitOfWork : IDisposable
    {
        private SignLanguageContex databaseContex;
        public UnitOfWork(SignLanguageContex databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        #region Support for each repository
        
        IRepository<BadMeaningWords> badMeaningWordsRepository = null;
        IRepository<GoodMeaningWords> goodMeaningWordsRepository = null;
        IRepository<LogException> logExceptionRepository = null;
        IRepository<UsersScoreQuiz> usersScoreQuizRepository = null;

        #endregion

        #region Set get for each repository

        public IRepository<UsersScoreQuiz> UsersScoreQuizRepository
        {
            get
            {
                if (usersScoreQuizRepository == null)
                    usersScoreQuizRepository = new UsersScoreQuizRepository(databaseContex);
                return usersScoreQuizRepository;
            }
        }

        public IRepository<LogException> LogExceptionRepository
        {
            get
            {
                if (logExceptionRepository == null)
                    logExceptionRepository = new LogExceptionRepository(databaseContex);
                return logExceptionRepository;
            }
        }

        public IRepository<GoodMeaningWords> GoodMeaningWordsRepository
        {
            get
            {
                if (goodMeaningWordsRepository == null)
                    goodMeaningWordsRepository = new GoodMeaningWordsRepository(databaseContex);
                return goodMeaningWordsRepository;
            }
        }

        public IRepository<BadMeaningWords> BadMeaningRepository
        {
            get
            {
                if (badMeaningWordsRepository == null)
                    badMeaningWordsRepository = new BadMeaningWordsRepository(databaseContex);
                return badMeaningWordsRepository;
            }
        }

        #endregion

        public void SaveChanges()
        {
            databaseContex.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    databaseContex.Dispose();
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

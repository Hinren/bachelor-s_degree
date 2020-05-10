using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF.Repository
{
    public interface IGoodMeaningWordsRepository<T> : IRepository<T> where T : class   
    {
        List<T> Get10RandomWordsThatHaveAtLeast3BadMeaning();
    }
}

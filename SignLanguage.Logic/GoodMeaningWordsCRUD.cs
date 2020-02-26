using SignLanguage.ADO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.Logic
{
    public class GoodMeaningWordsCRUD
    {
        public static List<SignLanguage.Models.GoodMeaningWords> GetWordsToLearn()
        {
            var context = new SignlanguageDatabaseContext();
            List<SignLanguage.Models.GoodMeaningWords> repoGoodMeaningWords = new List<SignLanguage.Models.GoodMeaningWords>();

            var goodMeaningWords = context.GoodMeaningWords;

            foreach (var word in goodMeaningWords)
            {
                repoGoodMeaningWords.Add(new SignLanguage.Models.GoodMeaningWords
                {
                    IdGoodMeaningWord = word.IdGoodMeaningWord,
                    Meaning = word.Meaning,
                    Url = word.Url
                });
            }

            return repoGoodMeaningWords;
        }
    }
}

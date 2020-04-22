using SignLanguage.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.Logic
{
    public class GoodMeaningWordsCRUD
    {
        public static List<GoodMeaningWords> GetWordsToLearn()
        {
            var context = new SignLanguageContex();
            List<GoodMeaningWords> repoGoodMeaningWords = new List<GoodMeaningWords>();

            var goodMeaningWords = context.GoodMeaningWords;

            foreach (var word in goodMeaningWords)
            {
                repoGoodMeaningWords.Add(new GoodMeaningWords
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

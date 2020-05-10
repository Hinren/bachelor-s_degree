using System;
using System.Collections.Generic;
using System.Linq;

namespace SignLanguage.Extension
{
    public static class ListExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection, int size)
        {
            var r = new Random();
            IEnumerable<T> shuffledList;
            if (collection.Count() > 10)
            {
                shuffledList =
                collection.
                    Select(x => new { Number = r.Next(), Item = x }).
                    OrderBy(x => x.Number).
                    Select(x => x.Item).
                    Take(size);
            }
            else
            {
                shuffledList =
                collection.
                    Select(x => new { Number = r.Next(), Item = x }).
                    OrderBy(x => x.Number).
                    Select(x => x.Item).
                    Take(size);
            }

            return shuffledList.ToList();
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            var r = new Random();
            var shuffledList =
            collection.
                Select(x => new { Number = r.Next(), Item = x }).
                OrderBy(x => x.Number).
                Select(x => x.Item).
                Take(collection.Count());

            return shuffledList.ToList();
        }
    }
}

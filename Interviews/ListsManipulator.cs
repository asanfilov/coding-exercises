using System.Collections.Generic;
using System.Linq;

namespace Interviews

{
    public class ListsManipulator
    {
        /// <summary>
        /// Merges inputs into a single list.
        /// </summary>
        /// <returns>List with unique values, ordered as follows: most character count to least character count
        /// (in the event of a tie, reverse alphabetical).
        /// </returns>
        public static IList<string> Merge(List<string> original,
                                          List<string> added,
                                          List<string> removed)
        {
            return original.Concat(added).Except(removed).Distinct()
                .OrderByDescending(s => s.Length)
                .ThenByDescending(s => s)
                .ToList();
        }
    }
}

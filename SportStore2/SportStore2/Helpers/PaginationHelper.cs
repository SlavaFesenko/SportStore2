using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore2.Helpers
{
    public static class PaginationHelper
    {
        public static IQueryable<T> Paginate<T>(IQueryable<T> sortedItems, int pageNum, int pageSize)
        {
            // calculate the count of products to skip
            var skippedList = sortedItems.Skip((pageNum - 1) * pageSize);

            // from the cut list after skip take the first {_pageSize} products
            var neededPortion = skippedList.Take(pageSize);

            return neededPortion;
        }
    }
}

using System.Collections.Generic;

namespace PlannerApi.Models.Pagination
{
    /// <summary>
    /// The class used for paginated data handling
    /// </summary>
    /// <typeparam name="T">Paginated data type</typeparam>
    public class DataPage<T>
    {
        /// <summary>
        /// Pages of data fetched from a main data source.
        /// </summary>
        public List<T> Pages { get; set; }
        /// <summary>
        /// Is there any previous page possible to fetch
        /// </summary>
        public bool HasPreviousPage { get; set; }
        /// <summary>
        /// Is there any next page possible to fetch
        /// </summary>
        public bool HasNextPage { get; set; }
        /// <summary>
        /// Index of this page. <c>0</c> index -> first page.
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// Max page size. Max quantity of elements in the page.
        /// </summary>
        public int MaxPageSize { get; set; }
        /// <summary>
        /// Index of last page possible to fetch from WebAPI.
        /// </summary>
        public int LastPageIndex { get; set; }
    }
}

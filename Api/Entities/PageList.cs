using System;
using System.Collections.Generic;

namespace Api.Entities
{
    public class PageList<T> : List<T>
    {
        public PageList(List<T> items, int totalItems, int page, int limit)
        {
            Page = page;
            TotalItems = totalItems;
            Limit = limit;
            TotalPages = (int)Math.Ceiling(totalItems / (double)limit);
            Items = new List<T>();
            Items.AddRange(items);
        }

        public int Limit { get; }

        public int Page { get; }

        public int TotalPages { get; }

        public int TotalItems { get; }

        public List<T> Items { get; }

        public int? PreviousPage
        {
            get
            {
                if (Page > 1)
                    return Page - 1;

                return null;
            }
        }

        public int? NextPage
        {
            get
            {
                if (HasNextPage)
                    return Page + 1;

                return null;
            }
        }

        public bool HasNextPage
            => Page < TotalPages;
    }
}
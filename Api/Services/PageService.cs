using System;
using System.Linq;
using Api.Entities;

namespace Api.Services
{
    public class PageService<T> : IPageService<T>
    {
        public PageList<T> Page(IQueryable<T> items, int page, int limit)
        {
            if (page <= 0)
            {
                throw new ArgumentException("The page must be greater than 0");
            }

            if (limit < 5 || limit > 30)
            {
                throw new ArgumentException("The limit must be filled with values between 5 and 30");
            }

            var totalItens = items.Count();
            var results = items.Skip((page - 1) * limit).Take(limit).ToList();
            return new PageList<T>(results, totalItens, page, limit);
        }
    }
}
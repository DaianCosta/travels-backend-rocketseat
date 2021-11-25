using System;
using System.Linq;
using System.Collections.Generic;
using Api.Entities;
using Api.Services;
using Xunit;

namespace Tests.Services
{

    public class PageServiceTest
    {

        private readonly IPageService<Travel> service;


        public PageServiceTest()
        {
            service = new PageService<Travel>();
        }

        [Theory]
        [InlineData(1, 10, 100)]
        [InlineData(1, 20, 100)]
        [InlineData(10, 10, 100)]
        [InlineData(2, 30, 100)]
        [InlineData(4, 30, 100)]
        public void PagincacaoSucesso(int page, int limit, int total)
        {
            List<Travel> travels = GenerateTrips(page, limit, total);

            var result = service.Page(travels.AsQueryable(), page, limit);

            int? previousPage = null;
            int? nextPage = null;
            
            var totalPages = (int)Math.Ceiling(travels.Count / (double)limit);
            var totalItemsPage = travels.Skip((page - 1) * limit).Take(limit).ToList().Count;
            
            if (page < totalPages)
                nextPage = page + 1;

            if (page > 1)
                previousPage = page - 1;

            Assert.NotNull(result);
            Assert.Equal(result.Page, page);
            Assert.Equal(result.Items.Count, totalItemsPage);
            Assert.Equal(result.TotalPages, totalPages);
            Assert.Equal(result.TotalItems, travels.Count);
            Assert.Equal(result.Limit, limit);
            Assert.Equal(result.PreviousPage, previousPage);
            Assert.Equal(result.NextPage, nextPage);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 5)]
        [InlineData(1, 31)]
        [InlineData(1, 4)]
        public void PagincacaoErro(int page, int limit)
        {
            Assert.Throws<ArgumentException>(() => service.Page(null, page, limit));
        }

        private List<Travel> GenerateTrips(int page, int limit, int total)
        {
            List<Travel> travels = new List<Travel>();

            for (int i = 0; i < total; i++)
                travels.Add(new Travel()
                {
                    Id = Guid.NewGuid(),
                    Destiny = i.ToString(),
                    Date = DateTime.Now,
                });

            return travels;
        }



    }
}
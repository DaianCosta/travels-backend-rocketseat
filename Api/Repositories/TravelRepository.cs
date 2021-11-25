using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Api.Services;
using Api.Entities;
using Api.DbContexts;

namespace Api.Repositories
{
    public class TravelRepository : ITravelRepository, IDisposable
    {
        private readonly IValidateQueryService _validateQueryService;
        private readonly IPageService<Travel> _pageService;
        private readonly TravelContext _context;

        public TravelRepository(TravelContext context
                              , IPageService<Travel> pageService
                              , IValidateQueryService validateQuery)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));

            _pageService = pageService ??
                throw new ArgumentNullException(nameof(pageService));

            _validateQueryService = validateQuery ??
                throw new ArgumentNullException(nameof(validateQuery));
        }

        public PageList<Travel> GetAll(int? page, int? limit, string destiny)
        {
            var errors = _validateQueryService.Validate(destiny, page, limit);

            if (!string.IsNullOrEmpty(errors))
                throw new ArgumentException(errors);

            var travels = from s in _context.Travel
                         select s;

            if (!string.IsNullOrEmpty(destiny))
                travels = travels.Where(s => s.Destiny.Contains(destiny));
    
            return _pageService.Page(travels.AsNoTracking(), page.GetValueOrDefault(), limit.GetValueOrDefault());
        }

        public Travel Get(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            return _context.Travel
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
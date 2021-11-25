using Api.Entities;
using System.Linq;

namespace Api.Services
{
    public interface IPageService<T>
    {    
        PageList<T> Page(IQueryable<T> items, int page, int limit);
    }
}

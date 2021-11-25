using Api.Entities;
using System;

namespace Api.Repositories
{
    public interface ITravelRepository
    {
        PageList<Travel> GetAll(int? page, int? limit, string destiny);
        Travel Get(Guid id);
    }
}

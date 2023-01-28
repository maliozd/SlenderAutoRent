using Application.Repositories.Base;
using Domain.Entities;
using SharedFramework.Dtos.Request;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<Car> GetByIdWithNavigationsAsync(int id);
        PaginationQueryResponse<ICollection<Car>> GetPaged(PaginationRequest request);
    }
}

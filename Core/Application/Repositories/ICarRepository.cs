using Application.Repositories.Base;
using Domain.Entities;
using SharedFramework.Dtos.Request;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        IQueryable<Car> SpecsIncludedTable { get; }
        PaginationQueryResponse<ICollection<Car>> GetCarsPagedByBrand(int brandId, PaginationRequest request);
        PaginationQueryResponse<ICollection<Car>> GetPaged(PaginationRequest request);
        Task<ICollection<Car>> GetAllWithSpecsIncludedAsync();
        Task<Car> GetByIdWithNavigationsAsync(int id);
        Task<ICollection<Car>> GetAvailableCarsAsync();
    }
}

using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;
using SharedFramework.Dtos.Request;
using SharedFramework.Dtos.Response.QueryResponse;
using SharedFramework.Utilities;

namespace Persistence.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Car> GetByIdWithNavigationsAsync(int id)
        {
            return await Table.Include(c => c.BodyType).Include(c => c.Brand).Include(c => c.Transmission).FirstOrDefaultAsync(x => x.Id == id);
        }

        public PaginationQueryResponse<ICollection<Car>> GetPaged(PaginationRequest request)
        {
            var data = Table.Include(c => c.BodyType).Include(c => c.Brand).Include(c => c.Transmission).ToPagedList(request);
            int total = Table.Count();
            return new(data, total, request);

        }
    }
}

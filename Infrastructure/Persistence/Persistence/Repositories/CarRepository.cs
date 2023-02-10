using Application.Repositories;
using Domain.Entities;
using Domain.Enums;
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

        public IQueryable<Car> SpecsIncludedTable => Table.Include(c => c.BodyType).Include(c => c.Brand).Include(c => c.Transmission).Include(c => c.CarModel).Include(c => c.Color);

        public async Task<ICollection<Car>> GetAllWithSpecsIncludedAsync()
        {
            return await SpecsIncludedTable.ToListAsync();
        }

        public async Task<ICollection<Car>> GetAvailableCarsAsync()
        {
            var availableCars = await SpecsIncludedTable.Where(c => c.State == CarState.Available).ToListAsync();
            return availableCars;
        }
        public async Task<Car> GetByIdWithNavigationsAsync(int id)
        {
            return await SpecsIncludedTable.FirstOrDefaultAsync(x => x.Id == id);
        }
        public PaginationQueryResponse<ICollection<Car>> GetCarsPagedByBrand(int brandId, PaginationRequest request)
        {
            var totalCarCount = Table.Count();
            var cars = SpecsIncludedTable.Where(x => x.BrandId == brandId).ToPagedList(request);
            return new(cars, totalCarCount, request);
        }
        public PaginationQueryResponse<ICollection<Car>> GetPaged(PaginationRequest request)
        {
            var cars = SpecsIncludedTable.ToPagedList(request);

            return new(cars, cars.Count, request);
        }
    }
}

using Application.Features.Queries.Cars.Dtos;
using Application.Repositories;
using Application.Services.Abstract;
using AutoMapper;
using Domain.Entities;
using SharedFramework.Abstract.Command;
using SharedFramework.Dtos.Request;
using SharedFramework.Dtos.Response.CommandResponse;
using SharedFramework.Dtos.Response.QueryResponse;

namespace Application.Services.Concrete
{
    public class CarService : ICarService
    {
        readonly ICarRepository _carRepository;
        readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse> InsertAsync(ICommand commandDto)
        {
            Car entity = _mapper.Map<Car>(commandDto);
            await _carRepository.AddAsync(entity);
            var affected = await _carRepository.SaveAsync();
            return new CreateCommandResponse(affected > 0, affected);
        }

        public async Task<CommandResponse> DeleteAsync(ICommand commandDto)
        {
            var entity = _mapper.Map<Car>(commandDto);
            _carRepository.Delete(entity);
            var affected = await _carRepository.SaveAsync();
            return new CreateCommandResponse(affected > 0, affected);
        }

        public Task<CommandResponse> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResponse<ICollection<CarDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<QueryResponse<CarDto>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationQueryResponse<ICollection<CarDto>>> GetPagedAsync(PaginationRequest request)
        {
            throw new NotImplementedException();
        }


        public Task<CommandResponse> UpdateAsync(ICommand commandDto)
        {
            throw new NotImplementedException();
        }
    }
}

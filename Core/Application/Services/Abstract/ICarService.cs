using Application.Features.Queries.Cars.Dtos;
using SharedFramework.Abstract;
using SharedFramework.Abstract.Command;

namespace Application.Services.Abstract
{
    public interface ICarService : ICrudService<CarDto, ICommand>
    {
    }
}

using Application.Repositories;
using Application.Rules;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules : BaseRules
    {
        readonly ICarRepository _repository;

        public CarBusinessRules(ICarRepository repository)
        {
            _repository = repository;
        }
        public Car CarStateMustBeAvailableOnCreating(Car entity)
        {
            entity.State = CarState.Available;
            return entity;
        }
    }
}

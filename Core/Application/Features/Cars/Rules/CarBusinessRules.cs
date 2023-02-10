using Application.Rules;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules : BaseRules
    {
        public Car CarStateMustBeAvailableOnCreating(Car car)
        {
            car.State = CarState.Available;
            return car;
        }
    }
}

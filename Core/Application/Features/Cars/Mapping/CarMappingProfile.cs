﻿using Application.Features.Cars.Commands.UpdateCar;
using Application.Features.Cars.Dtos;
using Application.Features.Commands.Cars.Create;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Cars.Mapping
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<CreateCarCommandRequest, Car>();
            CreateMap<CarState, string>().ConvertUsing(state => state.ToString());

            CreateMap<Car, CarDetailDto>().
                ForMember(c => c.Brand, m => m.MapFrom(c => c.Brand.Name != null ? c.Brand.Name : "")).
                ForMember(c => c.BodyType, m => m.MapFrom(c => c.BodyType.Name != null ?
                c.BodyType.Name : ""
                )).
                ForMember(c => c.Transmission, m => m.MapFrom(c => c.Transmission.Type != null ? c.Transmission.Type : "")).
                ForMember(c => c.CarModel, m => m.MapFrom(c => c.CarModel.Name != null ? c.CarModel.Name : ""));

            CreateMap<UpdateCarCommandRequest, Car>().
                ForMember(c => c.State, m => m.MapFrom(c => (CarState)c.State));

            CreateMap<Car, UpdatedCarDto>().
                ForMember(c => c.Brand, m => m.MapFrom(c => c.Brand.Name != null ? c.Brand.Name : "")).
                ForMember(c => c.BodyType, m => m.MapFrom(c => c.BodyType.Name != null ?
                c.BodyType.Name : ""
                )).
                ForMember(c => c.Transmission, m => m.MapFrom(c => c.Transmission.Type != null ? c.Transmission.Type : "")).
                ForMember(c => c.CarModel, m => m.MapFrom(c => c.CarModel.Name != null ? c.CarModel.Name : ""));



        }
    }
}

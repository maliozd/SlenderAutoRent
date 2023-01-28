﻿using Domain.Entites.Base;
using Domain.Enums;

namespace Domain.Entities;

public partial class Car : BaseEntity
{

    public int BrandId { get; set; }

    public int BodyTypeId { get; set; }

    public int TransmissionId { get; set; }

    public int? CarInventoryId { get; set; }
    public CarState CarState { get; set; }

    public int Year { get; set; }

    public int Mileage { get; set; }

    public int SeatCount { get; set; }

    public int HorsePower { get; set; }

    public string Color { get; set; } = null!;


    public virtual BodyType BodyType { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual CarInventory? CarInventory { get; set; }

    public virtual ICollection<Rental> Rentals { get; } = new List<Rental>();

    public virtual Transmission Transmission { get; set; } = null!;
}

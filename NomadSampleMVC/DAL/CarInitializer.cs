using NomadSampleMVC.Models;
using System;
using System.Collections.Generic;
namespace NomadSampleMVC.DAL
{
    public class CarInitializer<T> : System.Data.Entity.DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext context)
        {
            var carTypes = new List<CarType>
            {
            new CarType{Type="Economy"},
            new CarType{Type="Compact"},
            new CarType{Type="Intermediate"},
            new CarType{Type="Standard"},
            new CarType{Type="Full Size"},
            new CarType{Type="Premium"},
            new CarType{Type="Luxury"}
            };

            carTypes.ForEach(s => context.CarTypes.Add(s));
            context.SaveChanges();

            var carMakes = new List<CarMake>
            {
            new CarMake{Make="Toyota"},
            new CarMake{Make="BMW"},
            new CarMake{Make="Mercedes"},
            new CarMake{Make="Honda"},
            new CarMake{Make="Kia"},
            new CarMake{Make="Hyundai"},
            new CarMake{Make="Acura"}
            };
            carMakes.ForEach(s => context.CarMakes.Add(s));
            context.SaveChanges();

            var carModel = new List<CarModel>
            {
            new CarModel{CarMakeID=1,CarTypeID=1,Model="Prius",Color="White"},
            new CarModel{CarMakeID=1,CarTypeID=2,Model="Camry",Color="Red"},
            new CarModel{CarMakeID=1,CarTypeID=2,Model="Corolla",Color="Maroon"},
            new CarModel{CarMakeID=2,CarTypeID=6,Model="X3",Color="Blue"},
            new CarModel{CarMakeID=2,CarTypeID=7,Model="M5",Color="White"},
            new CarModel{CarMakeID=2,CarTypeID=7,Model="M3",Color="Black"},
            new CarModel{CarMakeID=3,CarTypeID=5,Model="C300",Color="Gray"},
            new CarModel{CarMakeID=4,CarTypeID=3,Model="Civic",Color="Silver"},
            new CarModel{CarMakeID=4,CarTypeID=1,Model="Fit",Color="Gray"},
            new CarModel{CarMakeID=5,CarTypeID=1,Model="Cerato",Color="Red"},
            new CarModel{CarMakeID=6,CarTypeID=1,Model="Elantra",Color="Silver"},
            new CarModel{CarMakeID=7,CarTypeID=3,Model="TSX",Color="White"},
            };
            carModel.ForEach(s => context.CarModels.Add(s));
            context.SaveChanges();
        }
    }
}
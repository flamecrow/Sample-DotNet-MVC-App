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
            new CarMake{Name="Toyota"},
            new CarMake{Name="BMW"},
            new CarMake{Name="Mercedes"},
            new CarMake{Name="Honda"},
            new CarMake{Name="Kia"},
            new CarMake{Name="Hyundai"},
            new CarMake{Name="Acura"}
            };
            carMakes.ForEach(s => context.CarMakes.Add(s));
            context.SaveChanges();

            var carModel = new List<CarModel>
            {
            new CarModel{CarMakeID=1,CarTypeID=1,Name="Prius"},
            new CarModel{CarMakeID=1,CarTypeID=2,Name="Camry"},
            new CarModel{CarMakeID=1,CarTypeID=2,Name="Corolla"},
            new CarModel{CarMakeID=2,CarTypeID=6,Name="X3"},
            new CarModel{CarMakeID=2,CarTypeID=7,Name="M5"},
            new CarModel{CarMakeID=2,CarTypeID=7,Name="M3"},
            new CarModel{CarMakeID=3,CarTypeID=5,Name="C300"},
            new CarModel{CarMakeID=4,CarTypeID=3,Name="Civic",},
            new CarModel{CarMakeID=4,CarTypeID=1,Name="Fit"},
            new CarModel{CarMakeID=5,CarTypeID=1,Name="Cerato"},
            new CarModel{CarMakeID=6,CarTypeID=1,Name="Elantra"},
            new CarModel{CarMakeID=7,CarTypeID=3,Name="TSX"},
            };
            carModel.ForEach(s => context.CarModels.Add(s));
            context.SaveChanges();
        }
    }
}
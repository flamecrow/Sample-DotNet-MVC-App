using NomadSampleMVC.Models;
using System;
using System.Collections.Generic;
namespace NomadSampleMVC.DAL
{
    public class CarInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CarContext>
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
            new CarModel{CarMakeID=1,Name="Prius"},
            new CarModel{CarMakeID=1,Name="Camry"},
            new CarModel{CarMakeID=1,Name="Corolla"},
            new CarModel{CarMakeID=2,Name="X3"},
            new CarModel{CarMakeID=2,Name="M5"},
            new CarModel{CarMakeID=2,Name="M3"},
            new CarModel{CarMakeID=3,Name="C300"},
            new CarModel{CarMakeID=4,Name="Civic",},
            new CarModel{CarMakeID=4,Name="Fit"},
            new CarModel{CarMakeID=5,Name="Cerato"},
            new CarModel{CarMakeID=6,Name="Elantra"},
            new CarModel{CarMakeID=7,Name=""},
            };
            carModel.ForEach(s => context.CarModels.Add(s));
            context.SaveChanges();
        }
    }
}
﻿using CarFactoryContracts.BindingModels;
using CarFactoryContracts.StorageContracts;
using CarFactoryContracts.ViewModels;
using CarFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CarFactoryDatabaseImplement.Implements
{
    public class CarStorage : ICarStorage
    {
        public List<CarViewModel> GetFullList()
        {
            using var context = new CarFactoryDatabase();
            return context.Cars
            .Include(rec => rec.CarComponents)
            .ThenInclude(rec => rec.Component)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<CarViewModel> GetFilteredList(CarBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CarFactoryDatabase();
            return context.Cars
            .Include(rec => rec.CarComponents)
            .ThenInclude(rec => rec.Component)
            .Where(rec => rec.CarName.Contains(model.CarName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public CarViewModel GetElement(CarBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CarFactoryDatabase();
            var product = context.Cars
            .Include(rec => rec.CarComponents)
            .ThenInclude(rec => rec.Component)
            .FirstOrDefault(rec => rec.CarName == model.CarName ||
            rec.Id == model.Id);
            return product != null ? CreateModel(product) : null;
        }

        public void Insert(CarBindingModel model)
        {
            using var context = new CarFactoryDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Cars.Add(CreateModel(model, new Car(),
                context));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(CarBindingModel model)
        {
            using var context = new CarFactoryDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Cars.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(CarBindingModel model)
        {
            using var context = new CarFactoryDatabase();
            Car element = context.Cars.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Cars.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public static Car CreateModel(CarBindingModel model, Car car, CarFactoryDatabase context)
        {
            car.CarName = model.CarName;
            car.Price = model.Price;

            if (model.Id.HasValue)
            {
                var carComponents = context.CarComponents.Where(rec =>
                rec.CarId == model.Id.Value).ToList();
                context.CarComponents.RemoveRange(carComponents.Where(rec =>
                !model.CarComponents.ContainsKey(rec.ComponentId)).ToList());
                foreach(var updateComponent in carComponents)
                {
                    updateComponent.Count =
                    model.CarComponents[updateComponent.ComponentId].Item2;
                    model.CarComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            foreach(var cc in model.CarComponents)
            {
                context.CarComponents.Add(new CarComponent
                {
                    CarId = car.Id,
                    ComponentId = cc.Key,
                    Count = cc.Value.Item2
                });
                context.SaveChanges();
            }

            return car;
        }

        private static CarViewModel CreateModel(Car car)
        {
            return new CarViewModel
            {
                Id = car.Id,
                CarName = car.CarName,
                Price = car.Price,
                CarComponents = car.CarComponents
                .ToDictionary(recCC => recCC.ComponentId,
                recCC => (recCC.Component?.ComponentName, recCC.Count))
            };
        }
    }
}

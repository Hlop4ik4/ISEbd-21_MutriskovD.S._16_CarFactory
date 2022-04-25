using Microsoft.EntityFrameworkCore;
using CarFactoryDatabaseImplement.Models;
using CarFactoryContracts.BindingModels;
using CarFactoryContracts.StorageContracts;
using CarFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarFactoryDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new CarFactoryDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Car)
                    .Include(rec => rec.Client)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        ClientId = rec.ClientId,
                        ClientName = rec.Client.ClientName,
                        CarId = rec.CarId,
                        CarName = rec.Car.CarName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                    })
                    .ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarFactoryDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Car)
                    .Include(rec => rec.Client)
                    .Where(rec => rec.CarId == model.CarId || (model.DateFrom.GetHashCode() != 0 && model.DateTo.GetHashCode() != 0 && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) ||
                    (model.ClientId.HasValue && rec.ClientId == model.ClientId))
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        ClientId = rec.ClientId,
                        ClientName = rec.Client.ClientName,
                        CarId = rec.CarId,
                        CarName = rec.Car.CarName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                    })
                    .ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarFactoryDatabase())
            {
                Order order = context.Orders.Include(rec => rec.Car).Include(rec => rec.Client).FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    ClientName = order.Client.ClientName,
                    CarId = order.CarId,
                    CarName = order.Car.CarName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                } :
                null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new CarFactoryDatabase())
            {
                var order = new Order
                {
                    ClientId = model.ClientId.Value,
                    CarId = model.CarId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new CarFactoryDatabase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Элемент не найден");
                }
                order.ClientId = model.ClientId.Value;
                order.CarId = model.CarId;
                order.Count = model.Count;
                order.Sum = model.Sum;
                order.Status = model.Status;
                order.DateCreate = model.DateCreate;
                order.DateImplement = model.DateImplement;

                CreateModel(model, order);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new CarFactoryDatabase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarFactoryDatabase())
            {
                Car car = context.Cars.FirstOrDefault(rec => rec.Id == model.CarId);
                if (car != null)
                {
                    if (car.Orders == null)
                    {
                        car.Orders = new List<Order>();
                    }

                    car.Orders.Add(order);
                    context.Cars.Update(car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return order;
        }
    }
}

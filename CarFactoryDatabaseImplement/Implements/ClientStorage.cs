using CarFactoryContracts.BindingModels;
using CarFactoryContracts.StorageContracts;
using CarFactoryContracts.ViewModels;
using CarFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarFactoryDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using var context = new CarFactoryDatabase();
            return context.Clients
            .Select(CreateModel)
            .ToList();
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new CarFactoryDatabase();
            return context.Clients
                .Include(x => x.Orders)
                .Where(rec => rec.Email == model.Email && rec.Password == model.Password)
                .Select(CreateModel)
                .ToList();
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CarFactoryDatabase();
            var client = context.Clients.FirstOrDefault(rec => rec.Email == model.Email || rec.Id == model.Id);
            return client != null ? CreateModel(client) : null;
        }

        public void Insert(ClientBindingModel model)
        {
            using var context = new CarFactoryDatabase();
            context.Clients.Add(CreateModel(model, new Client()));
            context.SaveChanges();
        }

        public void Update(ClientBindingModel model)
        {
            using var context = new CarFactoryDatabase();
            var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(ClientBindingModel model)
        {
            using var context = new CarFactoryDatabase();
            Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Client CreateModel(ClientBindingModel model, Client client)
        {
            client.Email = model.Email;
            client.ClientName = model.ClientName;
            client.Password = model.Password;
            return client;
        }

        private static ClientViewModel CreateModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientName = client.ClientName,
                Email = client.Email,
                Password = client.Password
            };
        }
    }
}

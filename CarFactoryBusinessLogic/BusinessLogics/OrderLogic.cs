using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFactoryContracts.BuisnessLogicsContracts;
using CarFactoryContracts.StorageContracts;
using CarFactoryContracts.BindingModels;
using CarFactoryContracts.ViewModels;
using CarFactoryContracts.Enums;
using CarFactoryBusinessLogic.MailWorker;


namespace CarFactoryBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;

        private readonly IClientStorage _clientStorage;

        private readonly AbstractMailWorker _mailWorker;

        public OrderLogic(IOrderStorage orderStorage, IClientStorage clientStorage, AbstractMailWorker mailWorker)
        {
            _orderStorage = orderStorage;
            _clientStorage = clientStorage;
            _mailWorker = mailWorker;
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model)};
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                ClientId = model.ClientId,
                CarId = model.CarId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = model.ClientId })?.Email,
                Subject = "Новый заказ",
                Text = $"Заказ от {DateTime.Now} на сумму {model.Sum} взят в работу."
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if(order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = model.ImplementerId,
                CarId = order.CarId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                Status = OrderStatus.Выполняется
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = $"Заказ №{order.Id}",
                Text = $"Заказ №{order.Id} выполняется."
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                CarId = order.CarId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Готов
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = $"Заказ №{order.Id}",
                Text = $"Заказ №{order.Id} готов."
            });
        }

        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId,
                ImplementerId = model.ImplementerId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ!");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                CarId = order.CarId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Выдан
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = $"Заказ №{order.Id}",
                Text = $"Заказ №{order.Id} выдан."
            });
        }
    }
}

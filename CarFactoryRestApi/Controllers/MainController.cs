using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CarFactoryContracts.BindingModels;
using CarFactoryContracts.BuisnessLogicsContracts;
using CarFactoryContracts.ViewModels;

namespace CarFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly ICarLogic _car;

        public MainController(IOrderLogic order, ICarLogic car)
        {
            _order = order;
            _car = car;
        }

        [HttpGet]
        public List<CarViewModel> GetCarList() => _car.Read(null)?.ToList();

        [HttpGet]
        public CarViewModel GetCar(int carId)
        {
            var rec = _car.Read(new CarBindingModel { Id = carId })?[0];
            return rec;
        }

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}

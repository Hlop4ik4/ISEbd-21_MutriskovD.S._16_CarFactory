using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarFactoryContracts.BindingModels;
using CarFactoryContracts.BuisnessLogicsContracts;
using CarFactoryContracts.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CarFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientLogic _logic;
        private readonly IMessageInfoLogic _message;

        public ClientController(IClientLogic logic, IMessageInfoLogic message)
        {
            _logic = logic;
            _message = message;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password)
        {
            var list = _logic.Read(new ClientBindingModel { Email = login, Password = password });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        [HttpGet]
        public List<MessageInfoViewModel> GetMailList() => _message.Read(null)?.ToList();

        [HttpPost]
        public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
    }
}

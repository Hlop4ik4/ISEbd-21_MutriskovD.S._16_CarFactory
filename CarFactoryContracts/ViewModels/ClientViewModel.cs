using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CarFactoryContracts.Attributes;
using System.Runtime.Serialization;

namespace CarFactoryContracts.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Column(title: "Имя клиента", width: 150)]
        public string ClientName { get; set; }

        [Column(title: "Почта клиента", width: 150)]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}

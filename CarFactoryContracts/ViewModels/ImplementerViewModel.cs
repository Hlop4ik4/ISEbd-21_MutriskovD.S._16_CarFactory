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
    public class ImplementerViewModel
    {
        public int Id { get; set; }

        [Column(title: "Имя исполнителя", width: 150)]
        public string Name { get; set; }

        [Column(title: "Время на заказ", width: 150)]
        public int WorkingTime { get; set; }

        [Column(title: "Время на отдых", width: 150)]
        public int PauseTime { get; set; }
    }
}

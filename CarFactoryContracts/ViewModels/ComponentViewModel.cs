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
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [Column(title: "Название изделия", width: 150)]
        public string ComponentName { get; set; }
    }
}

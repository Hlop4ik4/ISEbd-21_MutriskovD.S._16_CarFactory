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
    public class CarViewModel
    {
        public int Id { get; set; }

        [Column(title: "Автомобиль", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string CarName { get; set; }

        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> CarComponents { get; set; }
    }
}

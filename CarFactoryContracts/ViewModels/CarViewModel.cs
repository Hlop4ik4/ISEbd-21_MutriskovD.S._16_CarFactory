using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;

namespace CarFactoryContracts.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название автомобиля")]
        public string CarName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> CarComponents { get; set; }
    }
}

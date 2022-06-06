using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using CarFactoryContracts.Enums;
using CarFactoryContracts.Attributes;
using System.Runtime.Serialization;

namespace CarFactoryContracts.ViewModels
{
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        public int CarId { get; set; }

        public int ClientId { get; set; }

        public int? ImplementerId { get; set; }

        [Column(title: "Автомобиль", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string CarName { get; set; }

        [Column(title: "Клиент", width: 150)]
        public string ClientName { get; set; }

        [Column(title: "Исполнитель", width: 150)]
        public string ImplementerName { get; set; }

        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }

        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }

        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }

        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
    }
}

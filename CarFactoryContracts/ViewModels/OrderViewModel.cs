using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using CarFactoryContracts.Enums;

namespace CarFactoryContracts.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        [DisplayName("Id клиента")]
        public int ClientId { get; set; }

        public int? ImplementerId { get; set; }

        [DisplayName("Изделие")]
        public string CarName { get; set; }

        [DisplayName("Имя клиента")]
        public string ClientName { get; set; }

        [DisplayName("Имя исполнителя")]
        public string ImplementerName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}

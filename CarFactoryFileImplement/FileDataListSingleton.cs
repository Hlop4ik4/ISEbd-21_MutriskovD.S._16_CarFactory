using CarFactoryContracts.Enums;
using CarFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CarFactoryFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string CarFileName = "Car.xml";

        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Car> Cars { get; set; }

        private FileDataListSingleton()
        {
           // Components = LoadComponents();
           // Orders = LoadOrders();
           // Cars = LoadCars();
        }

        public static FileDataListSingleton GetInstance()
        {
            if(instance == null)
            {
                instance = new FileDataListSingleton();
            }

            return instance;
        }

        public void SaveData()
        {
            SaveComponents();
            SaveOrders();
            SaveCars();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach(var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach(var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CarId = Convert.ToInt32(elem.Attribute("CarId").Value),
                        Count = Convert.ToInt32(elem.Attribute("Count").Value),
                        Sum = Convert.ToDecimal(elem.Attribute("Sum").Value),
                        Status = (OrderStatus)Convert.ToInt32(elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = !string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? Convert.ToDateTime(elem.Element("DateImplement").Value) : (DateTime?)null
                    });
                }
            }
            return list;
        }

        private List<Car> LoadCars()
        {
            var list = new List<Car>();
            if (File.Exists(CarFileName))
            {
                var xDocument = XDocument.Load(CarFileName);
                var xElements = xDocument.Root.Elements("Car").ToList();

                foreach(var elem in xElements)
                {
                    var carComp = new Dictionary<int, int>();
                    foreach(var component in elem.Element("CarComponents").Elements("CarComponent").ToList())
                    {
                        carComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Car
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CarName = elem.Element("CarName").Value,
                        Price = Convert.ToDecimal(elem.Attribute("Price").Value),
                        CarComponents = carComp
                    });
                }
            }
            return list;
        }

        private void SaveComponents()
        {
            if(Components != null)
            {
                var xElement = new XElement("Components");

                foreach(var component in Components)
                {
                    xElement.Add(new XElement("Component",
                        new XAttribute("Id", component.Id),
                        new XElement("ComponentName", component.ComponentName)));
                }

                var xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders()
        {
            if(Orders != null)
            {
                var xElement = new XElement("Orders");

                foreach(var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XAttribute("CarId", order.CarId),
                        new XAttribute("Count", order.Count),
                        new XAttribute("Sum", order.Sum),
                        new XElement("Status", order.Status),
                        new XElement("DateCreate", order.DateCreate.ToString()),
                        new XElement("DateImplement", order.DateImplement?.ToString())));
                }

                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveCars()
        {
            if(Cars != null)
            {
                var xElement = new XElement("Cars");

                foreach(var car in Cars)
                {
                    var compElement = new XElement("CarComponents");
                    foreach(var component in car.CarComponents)
                    {
                        compElement.Add(new XElement("CarComponent",
                            new XElement("Key", component.Key),
                            new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Car",
                        new XAttribute("Id", car.Id),
                        new XElement("CarName", car.CarName),
                        new XElement("Price", car.Price),
                        compElement));
                }

                var xDocument = new XDocument(xElement);
                xDocument.Save(CarFileName);
            }
        }
    }
}

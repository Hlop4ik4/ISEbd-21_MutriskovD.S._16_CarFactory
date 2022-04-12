using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFactoryBusinessLogic.OfficePackage;
using CarFactoryBusinessLogic.OfficePackage.HelperModels;
using CarFactoryContracts.BindingModels;
using CarFactoryContracts.BuisnessLogicsContracts;
using CarFactoryContracts.StorageContracts;
using CarFactoryContracts.ViewModels;

namespace CarFactoryBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly ICarStorage _carStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(ICarStorage carStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _carStorage = carStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        public List<ReportCarComponentViewModel> GetCarComponent()
        {
            var cars = _carStorage.GetFullList();
            var list = new List<ReportCarComponentViewModel>();
            foreach (var car in cars)
            {
                var record = new ReportCarComponentViewModel
                {
                    CarName = car.CarName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in car.CarComponents)
                {
                        record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                        record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                CarName = x.CarName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список автомобилей",
                Cars = _carStorage.GetFullList()
            });
        }

        public void SaveCarComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список автомобилей",
                CarComponents = GetCarComponent()
            });
        }

        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}

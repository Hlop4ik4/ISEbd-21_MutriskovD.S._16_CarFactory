using CarFactoryContracts.BindingModels;
using CarFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace CarFactoryContracts.BuisnessLogicsContracts
{
    public interface ICarLogic
    {
        List<CarViewModel> Read(CarBindingModel model);
        void CreateOrUpdate(CarBindingModel model);
        void Delete(CarBindingModel model);
    }
}

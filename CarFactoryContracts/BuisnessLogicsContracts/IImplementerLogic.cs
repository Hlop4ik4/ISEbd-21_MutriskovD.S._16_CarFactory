using CarFactoryContracts.BindingModels;
using CarFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace CarFactoryContracts.BuisnessLogicsContracts
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);
        void CreateOrUpdate(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);
    }
}

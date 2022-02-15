using CarFactoryContracts.BindingModels;
using CarFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace CarFactoryContracts.StorageContracts
{
    public interface IComponentStorage
    {
        List<ComponentViewModel> GetFullList();
        List<ComponentViewModel> GetFilteredList(ComponentBindingModel model);
        ComponentViewModel GetElement(ComponentBindingModel model);
        void Insert(ComponentBindingModel model);
        void Update(ComponentBindingModel model);
        void Delete(ComponentBindingModel model);
    }
}

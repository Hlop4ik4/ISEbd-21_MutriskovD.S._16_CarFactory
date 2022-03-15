using CarFactoryContracts.BindingModels;
using CarFactoryContracts.ViewModels;
using System.Collections.Generic;


namespace CarFactoryContracts.StorageContracts
{
    public interface ICarStorage
    {
        List<CarViewModel> GetFullList();
        List<CarViewModel> GetFilteredList(CarBindingModel model);
        CarViewModel GetElement(CarBindingModel model);
        void Insert(CarBindingModel model);
        void Update(CarBindingModel model);
        void Delete(CarBindingModel model);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFactoryContracts.ViewModels;
using CarFactoryContracts.BindingModels;

namespace CarFactoryContracts.StorageContracts
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();

        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);

        void Insert(MessageInfoBindingModel model);
    }
}

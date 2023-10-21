using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.StoragesContracts
{
    public interface ITypeStorage
    {
        List<TypeViewModel> GetFullList();
        TypeViewModel? GetElement(TypeSearchModel model);
        TypeViewModel? Insert(TypeBindingModel model);
        TypeViewModel? Update(TypeBindingModel model);
        TypeViewModel? Delete(TypeBindingModel model);
    }
}

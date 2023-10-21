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
    public interface IProviderStorage
    {
        List<ProviderViewModel> GetFullList();
        ProviderViewModel? GetElement(ProviderSearchModel model);
        List<ProviderViewModel> GetFilteredList(ProviderSearchModel model);
        ProviderViewModel? Insert(ProviderBindingModel model);
        ProviderViewModel? Update(ProviderBindingModel model);
        ProviderViewModel? Delete(ProviderBindingModel model);
    }
}

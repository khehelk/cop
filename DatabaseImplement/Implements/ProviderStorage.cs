using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Implements
{
    public class ProviderStorage : IProviderStorage
    {
        public ProviderViewModel? Delete(ProviderBindingModel model)
        {
            using var context = new DB();
            var element = context.Providers
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) return null;
            context.Providers
                .Remove(element);
            context.SaveChanges();
            return element.GetViewModel;
        }

        public ProviderViewModel? GetElement(ProviderSearchModel model)
        {
            if (!model.Id.HasValue) return null;
            using var context = new DB();
            return context.Providers
                .FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
                ?.GetViewModel;
        }

        public List<ProviderViewModel> GetFilteredList(ProviderSearchModel model)
        {
            using var context = new DB();
            return context.Providers
                //.Where(x => )
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ProviderViewModel> GetFullList()
        {
            using var context = new DB();
            return context.Providers
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public ProviderViewModel? Insert(ProviderBindingModel model)
        {
            var newProvider = Provider.Create(model);
            if (newProvider == null) return null;            
            using var context = new DB();
            context.Providers
                .Add(newProvider);
            context.SaveChanges();
            return newProvider.GetViewModel;
        }

        public ProviderViewModel? Update(ProviderBindingModel model)
        {
            using var context = new DB();
            var provider = context.Providers
                .FirstOrDefault(x => x.Id == model.Id);
            if (provider == null) return null;            
            provider.Update(model);
            context.SaveChanges();
            return provider.GetViewModel;
        }
    }
}

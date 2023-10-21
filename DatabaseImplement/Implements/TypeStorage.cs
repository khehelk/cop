using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Implements
{
    public class TypeStorage : ITypeStorage
    {
        public TypeViewModel? Delete(TypeBindingModel model)
        {
            using var context = new DB();
            var element = context.Types
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) return null;            
            context.Types.Remove(element);
            context.SaveChanges();
            return element.GetViewModel;
        }

        public TypeViewModel? GetElement(TypeSearchModel model)
        {
            if (!model.Id.HasValue) return null;            
            using var context = new DB();
            return context.Types
                .FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
                ?.GetViewModel;
        }

        public List<TypeViewModel> GetFullList()
        {
            using var context = new DB();
            return context.Types
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public TypeViewModel? Insert(TypeBindingModel model)
        {
            var newType = Models.Type.Create(model);
            if (newType == null) return null;           
            using var context = new DB();
            context.Types
                .Add(newType);
            context.SaveChanges();
            return newType.GetViewModel;
        }

        public TypeViewModel? Update(TypeBindingModel model)
        {
            using var context = new DB();
            var type = context.Types
                .FirstOrDefault(x => x.Id == model.Id);
            if (type == null) return null;            
            type.Update(model);
            context.SaveChanges();
            return type.GetViewModel;
        }
    }
}

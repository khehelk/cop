using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Models
{
    public class Type : IType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public static Type? Create(TypeBindingModel model)
        {
            if (model == null) return null;
            return new Type()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public void Update(TypeBindingModel? model)
        {
            if (model == null) return;
            Name = model.Name;
        }

        public TypeViewModel GetViewModel => new()
        {
            Id = Id,
            Name = Name,
        };
    }
}

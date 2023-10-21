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
    public class Provider : IProvider
    {        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Furniture { get; set; }
        public DateTime? SupplyDate { get; set; }

        public static Provider? Create(ProviderBindingModel model)
        {
            if (model == null) return null;
            return new Provider()
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                Furniture = model.Furniture,
                SupplyDate = model.SupplyDate,
            };
        }

        public void Update(ProviderBindingModel model)
        {
            if (model == null) return;
            Name = model.Name;
            Type = model.Type;
            Furniture = model.Furniture;
            SupplyDate = model.SupplyDate;
        }

        public ProviderViewModel GetViewModel => new()
        {
            Id = Id,
            Name = Name,
            Type = Type,
            Furniture = Furniture,
            SupplyDate = SupplyDate,
        };
    }
}

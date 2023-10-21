using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BindingModels
{
    public class TypeBindingModel:IType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TypeBindingModel() { }

        public TypeBindingModel(IType type)
        {
            Id = type.Id;
        }
    }
}

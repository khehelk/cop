using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewModels
{
    public class TypeViewModel:IType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

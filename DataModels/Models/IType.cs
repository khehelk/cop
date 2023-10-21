using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public interface IType:IId
    {
        string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public interface IProvider : IId
    {
        string Name { get; set; }
        string Type { get; set; }
        string Furniture { get; set; }
        DateTime? SupplyDate { get; set; }
    }
}

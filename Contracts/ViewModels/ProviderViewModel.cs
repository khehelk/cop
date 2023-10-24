using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ViewModels
{
    public class ProviderViewModel:IProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Furniture { get; set; }
        public DateTime? SupplyDate { get; set; }       
        public string? SupplyDateTime { get; set; }
    }
}

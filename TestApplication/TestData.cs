using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public class TestData
    { 
        public int Id {  get; set; }
        public string University { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public TestData(
            int id,
            string university,
            string name,
            string city
        ){
            Id = id;
            University = university;
            Name = name; 
            City = city;
        }
    }
}

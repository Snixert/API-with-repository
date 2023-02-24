using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Friday.Repository.Models
{
    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}

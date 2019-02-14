using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPizzas.Models
{
    public class Pizza
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string[] precio { get; set; }
        public List<string> ingredientes { get; set; }
        public string alergenos { get; set; }
        public string img { get; set; }
    }
}

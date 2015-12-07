using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class HomeViewModel
    {
        public string WhoAmI { get; set; }
        public string HalveItOriginal { get; set; }
        public List<double> Halves { get; set; }
    }
}

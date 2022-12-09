using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application.ViewModels
{
    public class BaseEntityVM
    {
        public int Id { get; set; }
        public string Personality { get; set; }
        public int TCKN { get; set; }
    }
}

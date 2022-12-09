using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application.ViewModels
{
    public class CancelAppVM : BaseEntityVM
    {
        public int Phone { get; set; }
        public string Why { get; set; }
        public string ReferenceCode { get; set; }
    }
}

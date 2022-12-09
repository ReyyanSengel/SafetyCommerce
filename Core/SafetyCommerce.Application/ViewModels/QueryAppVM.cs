using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application.ViewModels
{
    public class QueryAppVM : BaseEntityVM
    {
        public int Phone { get; set; }
        public string ReferenceCode { get; set; }
        public string ApplicationStatus { get; set; }
        public string PayInformation { get; set; }
    }
}

using SafetyCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Domain.Entities
{
    public class CancelApp : BaseEntity
    {
        public int Phone { get; set; }
        public string Why { get; set; }
        public string ReferenceCode { get; set; }
    }
}

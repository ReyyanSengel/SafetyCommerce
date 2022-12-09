using SafetyCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Domain.Entities
{
    public class ReceiverApp : BaseEntity
    {
        public string NameSurname { get; set; }
        public int ReceiverPhone { get; set; }
        public string ReferenceCode { get; set; }
       
    }
}

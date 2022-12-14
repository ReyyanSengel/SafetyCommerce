using SafetyCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Domain.Entities
{
    public class SupplierApp : BaseEntity
    {
        public string NameSurname { get; set; }
        public string SupplierEmail { get; set; }
        public int SupplierPhone { get; set; }
        public string ReceiverEmail { get; set; }
        public int ReceiverPhone { get; set; }
        public string SupplierIBAN { get; set; }
        public string NumberPlate { get; set; }
        public decimal Price { get; set; }
        
    }
}

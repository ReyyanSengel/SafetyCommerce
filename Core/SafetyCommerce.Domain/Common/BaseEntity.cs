using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Personality { get; set; }
        public string TCKN { get; set; }
        
    }
}

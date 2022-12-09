using AutoMapper;
using SafetyCommerce.Application.ViewModels;
using SafetyCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SupplierApp,SupplierAppVM>().ReverseMap();
        }
    }
}

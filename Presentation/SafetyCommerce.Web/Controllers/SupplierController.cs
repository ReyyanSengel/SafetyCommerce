using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafetyCommerce.Application.Interfaces.IServices;
using SafetyCommerce.Application.ViewModels;
using SafetyCommerce.Domain.Entities;

namespace SafetyCommerce.Web.Controllers
{
    [AllowAnonymous]
    public class SupplierController : Controller
    {
        private readonly ISupplierAppService _supplierAppService;
        private readonly IMapper _mapper;

        public SupplierController(IMapper mapper, ISupplierAppService supplierAppService)
        {
            _mapper = mapper;
            _supplierAppService = supplierAppService;
        }


        public IActionResult SupplierApp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SupplierApp(SupplierAppVM supplier)
        {
            
            _supplierAppService.AddAsync(_mapper.Map<SupplierApp>(supplier));
            return RedirectToAction("AuthenticatorVerify", "TwoAuthentication");
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

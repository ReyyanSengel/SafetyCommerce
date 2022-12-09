using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafetyCommerce.Application.Interfaces.IServices;

namespace SafetyCommerce.Web.Controllers
{
    [AllowAnonymous]
    public class ReceiverController : Controller
    {
        private readonly IReceiverAppService _receiverAppService;
        private readonly IMapper _mapper;

        public ReceiverController(IReceiverAppService receiverAppService, IMapper mapper)
        {
            _receiverAppService = receiverAppService;
            _mapper = mapper;
        }

        public IActionResult ReceiverApp()
        {
            return View();
        }
    }
}

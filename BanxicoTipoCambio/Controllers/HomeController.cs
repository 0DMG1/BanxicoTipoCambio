using BanxicoTipoCambio.Api_Banxico;
using BanxicoTipoCambio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BanxicoTipoCambio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            BanxicoClient banxicoAPi = new BanxicoClient("52d0db3a102f9749f9b8d4e105d84b6c30be875726d917c3fbef092168867a61");

            return View(banxicoAPi.Respuesta);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
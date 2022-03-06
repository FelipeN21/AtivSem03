using AtivSem03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AtivSem03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpGet("/")]
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet("/Home/IndexAlunos")]
        public ActionResult PaginaAlunos()
        {

            return RedirectToAction("IndexAlunos", "Aluno");
           
        }
        [HttpGet("/Home/IndexCarros")]
        public ActionResult PaginaCarros()
        {


            return RedirectToAction("IndexCarros", "Carros");
        }





































        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

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
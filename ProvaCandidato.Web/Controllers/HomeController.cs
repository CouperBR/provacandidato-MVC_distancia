using ProvaCandidato.Services;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;
        public HomeController()
        {
            _homeService = new HomeService();
        }
        public ActionResult Index()
        {
            var nomeEmpresa = _homeService.GetNomeEmpresa();
            Session["CompanyName"] = nomeEmpresa;
            return View();
        }
    }
}
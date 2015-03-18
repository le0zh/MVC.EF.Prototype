using System.Web.Mvc;
using le0zh.Application.EmployeesManagement;
using le0zh.Domain.Employees;
using le0zh.Infrastructure.Data.Core;


namespace le0zh.Web.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeMgtService _employeeMgtService;

        public HomeController(EmployeeMgtService employeeMgtService)
        {
            _employeeMgtService = employeeMgtService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var list = _employeeMgtService.GetAll();
            ViewBag.Data = list;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

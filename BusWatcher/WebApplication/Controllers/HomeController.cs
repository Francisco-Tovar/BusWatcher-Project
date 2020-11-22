using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Security;


namespace WebApplication.Controllers
{
    [SecurityFilter]

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult vUsuarios()
        {
            return View();
        }
        public ActionResult vRegistrarAdmin()
        {
            return View();
        }
        public ActionResult vEmpresas()
        {
            return View();
        }
    }
}
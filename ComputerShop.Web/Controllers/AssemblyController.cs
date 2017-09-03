using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerShop.Web.Controllers
{
    public class AssemblyController : Controller
    {
        public AssemblyController()
        {

        }

        // GET: Assembly
        public ActionResult Index()
        {
            return View();
        }
    }
}
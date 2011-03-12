using System;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class NoteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

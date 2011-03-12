using System;
using System.Linq;
using System.Web.Mvc;
using ReadModel;

namespace Website.Controllers
{
    public class NoteController : Controller
    {
        public ActionResult Index()
        {
            using(var context = new ReadModelDataContext())
            {
                return View(context.NoteItems.ToList());
            }
        }
    }
}

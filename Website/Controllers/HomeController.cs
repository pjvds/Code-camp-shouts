using System;
using System.Linq;
using System.Web.Mvc;
using Commands;
using ReadModel;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(var context = new ReadModelDataContext())
            {
                return View(context.NoteItems.ToList());
            }
        }

        public ActionResult Edit(Guid id)
        {
            using(var context = new ReadModelDataContext())
            {
                var note = context.NoteItems.Single(n => n.Id == id);
                return View(new ChangeNoteTextCommand {NoteId = note.Id, NewText = note.Text});
            }
        }

        [HttpPost]
        public ActionResult Edit(ChangeNoteTextCommand command)
        {
            WebsiteApplication.CommandService.Execute(command);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult CreateNote()
        {
            var command = new CreateNewNoteCommand {NoteId = Guid.NewGuid()};
            return View(command);
        }

        [HttpPost]
        public ActionResult CreateNote(CreateNewNoteCommand command)
        {
            WebsiteApplication.CommandService.Execute(command);

            return View();
        }
    }
}

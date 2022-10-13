using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Controllers
{
    public class MeetController : Controller
    {
        List<Meet> meets = new List<Meet>
        {
            new Meet { MeetID = 0, MeetDate = "20/11/2022", Category = "Espalda"},
            new Meet { MeetID = 1, MeetDate = "25/11/2022", Category = "Croll"},
            new Meet { MeetID = 2, MeetDate = "30/11/2022", Category = "Croll"}
        };
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("[controller]/List")]
        // GET: MeetController
        public IEnumerable<Meet> List()
        {
            return meets;
        }

        [HttpGet("[controller]/Delete/{id}")]
        public IEnumerable<Meet> Delete(int id)
        {
            return meets;
        }

        [HttpGet("[controller]/Create/{MeetID}/{MeetDate}/{Category}")]
        public IEnumerable<Meet> Create(int MeetId, string MeetDate, string Category)
        {
            Meet m = new Meet();
            m.MeetID = MeetId;
            m.MeetDate = MeetDate;
            m.Category = Category;

            meets.Add(m);

            return meets;
        }

        // GET: MeetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MeetController/Create

        // POST: MeetController/Createº 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MeetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetController/Delete/5

        // POST: MeetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

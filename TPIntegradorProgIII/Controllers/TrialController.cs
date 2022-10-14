using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Controllers
{
    public class TrialController : Controller
    {
        List<Trial> trials = new List<Trial>
       {
        new Trial{ TrialID = 0, Distance= 100, Gender = "Masculino", Category = "Juvenil", Style = "Croll" },
        new Trial{ TrialID = 1, Distance= 100, Gender = "Femenino", Category = "Mayores", Style = "Croll" },
        new Trial{ TrialID = 2, Distance= 100, Gender = "Masculino", Category = "Juvenilt", Style = "Croll" }
        };
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("[controller]/List")]
        // GET: TrialController
        public IEnumerable<Trial> List()
        {
            return trials;
        }

        [HttpGet("[controller]/Delete/{id}")]
        public IEnumerable<Trial> Delete(int id)
        {
            return trials;
        }

        [HttpGet("[controller]/Create/{TrialID}/{Distance}/{Gender}/{Category}/{Style}")]
        public ICollection<Trial> Create(int TrialID, int Distance, string Gender, string Category, string Style)
        {
            Trial t = new Trial();
            t.TrialID = TrialID;
            t.Distance = Distance;
            t.Gender = Gender;
            t.Category = Category;
            t.Style = Style;

            trials.Add(t);

            return trials;
        }

        // GET: TrialController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrialController/Create

        // POST: TrialController/Create
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

        // GET: TrialController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrialController/Edit/5
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

        // GET: TrialController/Delete/5

        // POST: TrialController/Delete/5
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
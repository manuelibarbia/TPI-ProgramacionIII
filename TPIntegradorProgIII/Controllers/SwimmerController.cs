using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Controllers
{
    public class SwimmerController : Controller
    {
        List<Swimmer> swimmers = new List<Swimmer>
       {
        new Swimmer{ SwimmerID = 0, Name = "Matias", Surname = "Peralta", Document = 40555666, Phone = "3413334455", Adress = "HolaMundo al 1100", Birth = "10/10/2010" },
        new Swimmer{ SwimmerID = 1, Name = "Lucho", Surname = "Peralta", Document = 41555666, Phone = "3413334456", Adress = "HolaMundo al 1200", Birth = "10/10/2012" },
        new Swimmer{ SwimmerID = 2, Name = "Mati", Surname = "Solari", Document = 42555666, Phone = "3413334457", Adress = "HolaMundo al 1300", Birth = "10/10/2014", }
        };
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("[controller]/List")]
        // GET: SwimmerController
        public IEnumerable<Swimmer> List()
        {
            return swimmers;
        }

        [HttpGet("[controller]/Delete/{id}")]
        public IEnumerable<Swimmer> Delete(int id)
        {
            return swimmers;
        }

        [HttpGet("[controller]/Create/{SwimmerID}/{Name}/{Surname}/{Document}/{Phone}/{Adress}/{Birth}")]
        public ICollection<Swimmer> Create(int SwimmerID, string Name, string Surname, int Document, string Phone, string Adress, string Birth)
        {
            Swimmer s = new Swimmer();
            s.SwimmerID = SwimmerID;
            s.Name = Name;
            s.Surname = Surname;
            s.Document = Document;
            s.Phone = Phone;
            s.Adress = Adress;
            s.Birth = Birth;

            swimmers.Add(s);

            return swimmers;
        }

        // GET: SwimmerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SwimmerController/Create

        // POST: SwimmerController/Create
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

        // GET: SwimmerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SwimmerController/Edit/5
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

        // GET: SwimmerController/Delete/5

        // POST: SwimmerController/Delete/5
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

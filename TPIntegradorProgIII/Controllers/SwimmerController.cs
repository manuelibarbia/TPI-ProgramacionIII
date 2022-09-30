using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Controllers
{
    public class SwimmerController : Controller
    {
        List<Swimmer> cats = new List<Swimmer>
       {
        new Swimmer{ SwimmerID = 0, Name = "Matias", Surname = "Peralta", Document = 40555666, Phone = "3413334455", Adress = "HolaMundo al 1100", Birth = "10/10/2010" },
        new Swimmer{ SwimmerID = 1, Name = "Lucho", Surname = "Peralta", Document = 41555666, Phone = "3413334456", Adress = "HolaMundo al 1200", Birth = "10/10/2012" },
        new Swimmer{ SwimmerID = 2, Name = "Mati", Surname = "Solari", Document = 42555666, Phone = "3413334457", Adress = "HolaMundo al 1300", Birth = "10/10/2014", }
        };
        // GET: SwimmerController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet("[controller]/List")]
        public IEnumerable<WeatherForecast> List()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }
        [HttpGet("[controller]/Delete")]
        public IEnumerable<WeatherForecast> Delete()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }
        [HttpGet("[controller]/Createe")]
        public IEnumerable<WeatherForecast> Createe()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }

        // GET: SwimmerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SwimmerController/Create
        public ActionResult Create()
        {
            return View();
        }

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
        public ActionResult Delete(int id)
        {
            return View();
        }

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

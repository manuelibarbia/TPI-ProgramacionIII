using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.GuardarArchivos.GuardarControllers
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

        [HttpGet("[controller]/Create/{TrialID}/{Distance}/{Gender}/{Category}/{Style}")] //ALTA
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

        [HttpGet("[controller]/Delete/{id}")] //BAJA
        public IEnumerable<Trial> Delete(int id)
        {
            return trials;
        }

        [HttpPut("{swimmerId}/changestatus")]
        public ActionResult<QuestionDto> ChangeQuestionStatus(int questionId, QuestionStatusDto newStatus) //MODIFICACIÓN
        {
            _questionService.ChangeQuestionStatus(questionId, newStatus.Status);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<QuestionDto> CreateQuestion(QuestionForCreationDto newQuestion)  //CONSULTA
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }

            var createdQuestion = _questionService.CreateQuestion(newQuestion, userId);

            return CreatedAtRoute(//CreatedAtRoute es para q devuelva 201, el 200 de post.
                "GetQuestion", //El primer parámetro es el Name del endpoint que hace el Get
                new //El segundo los parametros q necesita ese endpoint
                {
                    questionId = createdQuestion.Id
                },
                createdQuestion);//El tercero es el objeto creado. 
        }

        [HttpGet("[controller]/List")]
        // GET: TrialController
        public IEnumerable<Trial> List()
        {
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
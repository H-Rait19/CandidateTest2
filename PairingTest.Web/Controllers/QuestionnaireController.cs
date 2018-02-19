using System.Web.Mvc;
using PairingTest.Web.Models;
using System.Collections.Generic;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        /* ASYNC ACTION METHOD... IF REQUIRED... */
        //        public async Task<ViewResult> Index()
        //        {
        //        }
        readonly QuestionnaireViewModel _questionnaireVm;

        public QuestionnaireController()
        {
            _questionnaireVm = new QuestionnaireViewModel();
        }

        public ViewResult Index()
        {
            _questionnaireVm.InitialiseQuestionnaire();
            return View("Index", _questionnaireVm);
        }

        [HttpPost]
        public ActionResult Index(string questionAnswerFor0, string questionAnswerFor1, string questionAnswerFor2, string questionAnswerFor3)
        {
            _questionnaireVm.Submit(new List<string> { questionAnswerFor0, questionAnswerFor1, questionAnswerFor2, questionAnswerFor3 });
            return PartialView("_Answers", _questionnaireVm);
        }
    }
}

using System.Collections.Generic;
using QuestionServiceWebApi.Controllers;
using QuestionServiceWebApi;

namespace PairingTest.Web.Models
{
    public class QuestionnaireViewModel
    {
        public string QuestionnaireTitle { get; set; }
        public IList<string> QuestionsText { get; set; }
        public IList<bool> Results { get; set; }
        readonly QuestionsController _qc;

        public QuestionnaireViewModel()
        {
            if (_qc == null)
            {
                _qc = new QuestionsController();
            }
        }

        public void InitialiseQuestionnaire()
        {
            var questionnaire = _qc.Get();

            QuestionnaireTitle = questionnaire.QuestionnaireTitle;
            QuestionsText = questionnaire.QuestionsText;
        }

        public void Submit(IList<string> answers)
        {
            CheckAnswers(answers);
        }

        private void CheckAnswers(IList<string> answers)
        {

            int count = 0;
            List<string> realAnswers = _qc.GetAnswers();
            Results = new List<bool>();
            if (answers.Count == realAnswers.Count)
            {
                foreach (var answer in realAnswers)
                {
                    if (answers[count].ToLower() == realAnswers[count].ToLower())
                    {
                        Results.Add(true);
                    }
                    else
                    {
                        Results.Add(false);
                    }
                    count++;
                }
            }
            else
            {
                foreach (var a in realAnswers)
                {
                    Results.Add(false);
                }
            }
        }
    }
}
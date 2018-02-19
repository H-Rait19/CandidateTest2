using System.Collections.Generic;

namespace QuestionServiceWebApi.Interfaces
{
    public interface IQuestionRepository
    {
        Questionnaire GetQuestionnaire();

        List<string> GetAnswers();
    }
}
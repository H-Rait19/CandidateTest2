using NUnit.Framework;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionRepositoryTests
    {
        [Test]
        public void ShouldGetExpectedQuestionnaire()
        {
            var questionRepository = new QuestionRepository();

            var questionnaire = questionRepository.GetQuestionnaire();

            Assert.That(questionnaire.QuestionnaireTitle, Is.EqualTo("Geography Questions"));
            Assert.That(questionnaire.QuestionsText[0], Is.EqualTo("What is the capital of Cuba?"));
            Assert.That(questionnaire.QuestionsText[1], Is.EqualTo("What is the capital of France?"));
            Assert.That(questionnaire.QuestionsText[2], Is.EqualTo("What is the capital of Poland?"));
            Assert.That(questionnaire.QuestionsText[3], Is.EqualTo("What is the capital of Germany?"));
        }

        [Test]
        public void ShouldGetExpectedQuestionnaireAnswers()
        {
            var questionRepository = new QuestionRepository();

            var questionnaire = questionRepository.GetAnswers();

            Assert.That(questionnaire[0], Is.EqualTo("Havana"));
            Assert.That(questionnaire[1], Is.EqualTo("Paris"));
            Assert.That(questionnaire[2], Is.EqualTo("Warsaw"));
            Assert.That(questionnaire[3], Is.EqualTo("Berlin"));
        }
    }
}
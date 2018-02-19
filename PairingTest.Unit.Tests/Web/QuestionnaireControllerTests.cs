using System.Collections.Generic;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "Geography Questions";
            var questionnaireController = new QuestionnaireController();

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void ShouldGetAnswersCorrect()
        {
            //Arrange
            List<string> answ = new List<string>();
            answ.Add("Havana");
            answ.Add("paris");
            answ.Add("WARSAW");
            answ.Add("BeRlIn");
            var questionnaireViewModel = new QuestionnaireViewModel();

            questionnaireViewModel.Submit(answ);

            var res = questionnaireViewModel.Results;

            //Assert
            Assert.That(res[0], Is.EqualTo(true));
            Assert.That(res[1], Is.EqualTo(true));
            Assert.That(res[2], Is.EqualTo(true));
            Assert.That(res[3], Is.EqualTo(true));
        }

        [Test]
        public void ShouldGetThreeWrongButOneRight()
        {
            //Arrange
            List<string> answ = new List<string>();
            answ.Add("Havasdana");
            answ.Add("PARIS");
            answ.Add(" ");
            answ.Add("");
            var questionnaireViewModel = new QuestionnaireViewModel();

            questionnaireViewModel.Submit(answ);

            var res = questionnaireViewModel.Results;

            //Assert
            Assert.That(res[0], Is.EqualTo(false));
            Assert.That(res[1], Is.EqualTo(true));
            Assert.That(res[2], Is.EqualTo(false));
            Assert.That(res[3], Is.EqualTo(false));
        }

        [Test]
        public void ShouldGetAnswersWrong()
        {
            //Arrange
            List<string> answ = new List<string>();
            answ.Add("AAAAAAAAA");
            answ.Add("6534");
            answ.Add(" ");
            answ.Add("");
            var questionnaireViewModel = new QuestionnaireViewModel();

            questionnaireViewModel.Submit(answ);

            var res = questionnaireViewModel.Results;

            //Assert
            Assert.That(res[0], Is.EqualTo(false));
            Assert.That(res[1], Is.EqualTo(false));
            Assert.That(res[2], Is.EqualTo(false));
            Assert.That(res[3], Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnAllFalseAsOnlyOneAnswerEntered()
        {
            //Arrange
            List<string> answ = new List<string>();
            answ.Add("Havana");
            var questionnaireViewModel = new QuestionnaireViewModel();

            questionnaireViewModel.Submit(answ);

            var res = questionnaireViewModel.Results;

            //Assert
            Assert.That(res[0], Is.EqualTo(false));
            Assert.That(res[1], Is.EqualTo(false));
            Assert.That(res[2], Is.EqualTo(false));
            Assert.That(res[3], Is.EqualTo(false));
        }
    }
}
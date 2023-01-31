using Business.PageObjects.Gmail;
using Core.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Tests.SpecflowTests.Steps.Gmail
{
    [Binding]
    public class ComposeMailStepDefinitions
    {
        MainPage _mainPage;
        DriverManager _driverManager;
        private ComposeMailStepDefinitions(DriverManager driverManager)
        {
            _driverManager = driverManager;
            _mainPage = new(_driverManager.GetDriver());
        }

        [When(@"click compose button")]
        public void WhenClickComposeButton()
        {
            _mainPage.ComposeNewMail();
        }

        [Then(@"verify that new mail dialog opened")]
        public void ThenVerifyThatNewMailDialogOpened()
        {
            IWebElement newMailDialog = _mainPage.messageDialog.NewMailDialog;
            Assert.IsTrue(newMailDialog.Displayed);
        }

        [Then(@"verify that all to, subject and body fields are empty")]
        public void ThenVerifyThatAllToSubjectAndBodyFieldsAreEmpty()
        {
            IWebElement toField = _mainPage.messageDialog.To;
            IWebElement subjectField = _mainPage.messageDialog.Subject;
            IWebElement bodyField = _mainPage.messageDialog.Body;
            Assert.Multiple(() =>
            {
                Assert.IsEmpty(toField.Text);
                Assert.IsEmpty(subjectField.Text);
                Assert.IsEmpty(bodyField.Text);
            });
        }
    }
}

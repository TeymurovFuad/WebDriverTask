using Business;
using Core.Business;
using Core.Utils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.SpecflowTests.Gmail.Steps
{
    [Binding]
    public class ComposeMailStepDefinitions: GmailHooks
    {
        [Given(@"email and password and page details")]
        public void GivenEmailAndPasswordAndPageDetails(Table table)
        {
            user = table.CreateInstance<User>();
            page = table.CreateInstance<Page>();
            LoginToGmail();
        }

        [When(@"click compose button")]
        public void WhenClickComposeButton()
        {
            mainPage.ComposeNewMail();
        }

        [Then(@"verify that new mail dialog opened")]
        public void ThenVerifyThatNewMailDialogOpened()
        {
            IWebElement newMailDialog = mainPage.messageDialog.NewMailDialog;
            Assert.IsTrue(newMailDialog.Displayed);
        }

        [Then(@"verify that all to, subject and body fields are empty")]
        public void ThenVerifyThatAllToSubjectAndBodyFieldsAreEmpty()
        {
            IWebElement toField = mainPage.messageDialog.To;
            IWebElement subjectField = mainPage.messageDialog.Subject;
            IWebElement bodyField = mainPage.messageDialog.Body;
            Assert.Multiple(() =>
            {
                Assert.IsEmpty(toField.Text);
                Assert.IsEmpty(subjectField.Text);
                Assert.IsEmpty(bodyField.Text);
            });
        }
    }
}

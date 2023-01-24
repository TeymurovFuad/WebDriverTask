using System;
using TechTalk.SpecFlow;

namespace GmailTest.Tests.Steps
{
    [Binding]
    public class Feature1StepDefinitions
    {
        [Given(@"testsd fsdfs")]
        public void GivenTestsdFsdfs()
        {
            throw new PendingStepException();
        }

        [When(@"tes tsdfsdf")]
        public void WhenTesTsdfsdf()
        {
            throw new PendingStepException();
        }

        [Then(@"testsd\tfsdf")]
        public void ThenTestsdFsdf()
        {
            throw new PendingStepException();
        }
    }
}

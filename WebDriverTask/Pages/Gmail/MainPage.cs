using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPage: MainPageElements
    {
        public void ComposeNewMail()
        {
            //string style = NewMessageBox.NewMessageDialogBox.GetAttribute("style");
            //string pattern = @".*height(.){1,3}\d+";
            if (isElementDisplayed(NewMessageBox.NewMessageDialogBox))
                ComposeButton.Click();
            DriverManager.WaitUntilElementIsInteractable(NewMessageBox.SendButton);
        }
    }
}

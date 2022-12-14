using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public interface IMailFolder
    {
        public string _folderSpecificIdendifierForRetreivingMails { get; }
        public string _folderSpecificIdendifierIfNoMailExists { get; }
        public List<IWebElement> GetDraftMails();
        public virtual IWebElement? GetMailFromTable() { return null; }
        public void Open();
    }
}

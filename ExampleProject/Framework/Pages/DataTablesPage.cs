using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace ExampleProject.Framework.Pages
{
    internal class DataTablesPage : Form
    {
        private const string PageName = "Data Tables";
        private static readonly By due = By.XPath("//*[@id='table1']//td[4]");
        
        public DataTablesPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public List<string> GetFirstDueList()
        {
            
            var dueList = new List<string>();
            foreach (var dueElement in GetFirstDueLblList())
            {
                dueList.Add(dueElement.Text);
            }
            return dueList;
        }

        private IList<ILabel> GetFirstDueLblList()
        {
            return ElementFactory.FindElements<ILabel>(due, "due label");
        }
    }
}

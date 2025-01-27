using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace ExampleProject.Framework
{
    public abstract class TableForm : Form
    {
        protected IElement Table => FormElement;
        protected abstract By RowLocator { get; }
        protected abstract By HeaderLocator { get; }


        public TableForm(By tableLocator, string tableName) : base(tableLocator, tableName)
        {
        }

        protected virtual List<string> GetHeadersTexts()
        {
            return Table.FindChildElements<IElement>(HeaderLocator, "Headers")
                .Select(element => element.GetText())
                .ToList();
        }

        protected virtual Dictionary<string, IElement> GetHeaderNameToElementRow()
        {
            var rowElements = Table.FindChildElements<IElement>(RowLocator).ToList();
            var headerNames = GetHeadersTexts();
            
            var headerNameToElement = new Dictionary<string, IElement>();
            for (int i = 0; i < headerNames.Count; i++)
            {
                headerNameToElement.Add(headerNames[i], rowElements[i]);
            }
            return headerNameToElement;
        }

        //protected virtual IElement GetCell
    }
}

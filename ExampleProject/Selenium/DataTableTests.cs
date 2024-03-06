using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace ExampleProject.Selenium
{
    internal class DataTableTests : BaseTest
    {
        private static readonly By sortableDataTables = By.XPath(string.Format(preciseTextXpath, "Sortable Data Tables"));
        private static readonly By dueColumn = By.XPath("//*[@id='table1']//td[4]");
        private static readonly double expecetedSum = 251.00;
        private static readonly string currencyRegex = "[^\\d.]";

        [Test]
        public void DataTableTest()
        {
            driver.FindElement(sortableDataTables).Click();
            var dueElements = driver.FindElements(dueColumn);
            var actualSum = 0.00;
            foreach (WebElement element in dueElements)
            {
                string elementText = element.Text;
                string numberFromText = Regex.Replace(elementText, currencyRegex, "");
                string numberWithCorrectSeparator = numberFromText.Replace(".", ",");
                actualSum += Convert.ToDouble(numberWithCorrectSeparator);
            }
            Assert.That(actualSum, Is.EqualTo(expecetedSum), "Sum is not correct");
        }
    }
}

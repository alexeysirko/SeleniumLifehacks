using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;

namespace ExampleProject.Selenium
{
    internal class FileDownloadTests : BaseTest
    {
        private static readonly string fileName = "Upload.txt";
        
        private static readonly By fileDownloadBtn = By.XPath(string.Format(preciseTextXpath, "File Download"));
        private static readonly By fileNameField = By.XPath(string.Format(preciseTextXpath, fileName));

        private static readonly string filePath = relativePathFolder + fileName;
        private static readonly FileInfo downloadedFile = new(Path.GetFullPath(filePath));

        [Test]
        public void FileDownloadTest()
        {
            driver.FindElement(fileDownloadBtn).Click();
            Assert.True(driver.FindElement(fileNameField).Displayed, "File is not displayed");
            driver.FindElement(fileNameField).Click();
            //assert file is downloaded
        }
        //delete the downloaded file
    }
}

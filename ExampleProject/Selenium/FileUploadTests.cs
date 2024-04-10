using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;

namespace ExampleProject.Selenium
{
    internal class FileUploadTests : BaseTest
    {
        private static readonly By fileUploadBtn = By.XPath(string.Format(preciseTextXpath, "File Upload"));
        private static readonly By chooseFileBtn = By.Id("file-upload");
        private static readonly By fileSubmitField = By.Id("file-submit");
        private static readonly By uploadedFileField = By.Id("uploaded-files");
        private static readonly string fileName = "ExampleFile.txt";
        private static readonly string filePath = relativePathFolder + fileName;

        [Test]
        public void FileUploadTest()
        {
            driver.FindElement(fileUploadBtn).Click();
            FileInfo fileToUpload = new(filePath);
            driver.FindElement(chooseFileBtn).SendKeys(fileToUpload.FullName);
            driver.FindElement(fileSubmitField).Click();
            Assert.That(driver.FindElement(uploadedFileField).Text, Is.EqualTo(fileName), "File name is not correct or missing");
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;

namespace ExampleProject.Selenium
{
    internal class FileDownloadTests : BaseTest
    {
        private static readonly By fileNameLocator = By.XPath("//*[@id='content']//a");

        private static readonly By fileDownloadBtn = By.XPath(string.Format(preciseTextXpath, "File Download"));
        private static By FileNameField(string fileName) => By.XPath(string.Format(preciseTextXpath, fileName));

        private static string FilePath(string fileName) => relativePathFolder + fileName;
        private static FileInfo downloadedFile;

        [Test]
        public void FileDownloadTest()
        {         
            driver.FindElement(fileDownloadBtn).Click();
            string fileName = driver.FindElement(fileNameLocator).Text;
            Assert.That(driver.FindElement(FileNameField(fileName)).Displayed, "File is not displayed");
            driver.FindElement(FileNameField(fileName)).Click();
            downloadedFile = new(Path.GetFullPath(FilePath(fileName)));
            wait.Until(condition => IsFileDownloaded(FilePath(fileName)));
            Assert.That(IsFileDownloaded(FilePath(fileName)), "File is not downloaded");
        }       

        private bool IsFileDownloaded(string filePath)
        {
            var newFile = new FileInfo(Path.GetFullPath(filePath));
            return newFile.Exists;
        }

        [TearDown]
        public void DeleteFile()
        {
            if (downloadedFile.Exists)
            {
                downloadedFile.Delete();
            }
        }
    }
}

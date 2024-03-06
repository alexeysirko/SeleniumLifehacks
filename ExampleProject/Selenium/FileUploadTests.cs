using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;

namespace ExampleProject.Selenium
{
    internal class FileUploadTests : BaseTest
    {
        private static readonly By fileUploadBtn = By.XPath(string.Format(preciseTextXpath, "File Upload"));
        private static readonly string fileName = "UploadFileExample.txt";
        private static readonly string filePath = relativePathFolder + fileName;

    [Test]
   public void FileUploadTest()
        {
            driver.FindElement(fileUploadBtn).Click();
            FileInfo fileToUpload = new(filePath);
            //upload a new file 
            //assert file is uploaded
        }
    }
}

using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using System.IO;

namespace ExampleProject.Framework.Tests
{
    [AllureEpic("File system")]
    internal class FileUploadTests : BaseTest
    {
        private static readonly FileUploadPage fileUploadPage = new();

        private static readonly string fileName = testdata.GetValue<string>("fileUpload.fileName");
        private static readonly string filePath = testdata.GetValue<string>("fileUpload.folderPath") + fileName;

        [Test]
        [AllureSuite("Files tests")]       
        [AllureSeverity(SeverityLevel.trivial)]
        public void FileUploadTest()
        {
            AllureApi.Step(nameof(fileUploadPage.ClickFileUploadBtn));
            fileUploadPage.ClickFileUploadBtn();
            AllureApi.Step(nameof(fileUploadPage.SendKeysToFileToChooseFileTxb));
            fileUploadPage.SendKeysToFileToChooseFileTxb(Path.GetFullPath(filePath));
            AllureApi.Step(nameof(fileUploadPage.ClickFileSubmitBtn));
            fileUploadPage.ClickFileSubmitBtn();
            Assert.That(fileUploadPage.GetNameOfUploadedFile(), Is.EqualTo(fileName));
        }
    }
}

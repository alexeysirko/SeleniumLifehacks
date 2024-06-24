using ExampleProject.Framework.Pages;
using NUnit.Framework;
using System.IO;

namespace ExampleProject.Framework.Tests
{
    internal class FileUploadTests : BaseTest
    {
        private static readonly FileUploadPage fileUploadPage = new();

        private static readonly string fileName = testdata.GetValue<string>("fileUpload.fileName");
        private static readonly string filePath = testdata.GetValue<string>("fileUpload.folderPath") + fileName;

        [Test]
        public void FileUploadTest()
        {
            fileUploadPage.ClickFileUploadBtn();
            fileUploadPage.SendKeysToFileToChooseFileTxb(Path.GetFullPath(filePath));
            fileUploadPage.ClickFileSubmitBtn();
            Assert.That(fileUploadPage.GetNameOfUploadedFile(), Is.EqualTo(fileName));
        }
    }
}

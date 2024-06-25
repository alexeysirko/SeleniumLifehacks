using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class FileUploadTests : BaseTest
    {
        private FileUploadPage fileUploadPage = new();
        private static readonly string fileName = testdata.GetValue<string>("fileUpload.fileName");
        private static readonly string filePath = testdata.GetValue<string>("fileUpload.folderPath") + fileName;


        [Test]

        public void FileUpload()
        {
            //mainPage.ClickNavigationLink("File Upload");
            fileUploadPage.SendKeysToChooseFile(FileUtils.GetAbsoluteFilePath(filePath));
            fileUploadPage.ClickSubmitButton();
            Assert.That(fileUploadPage.GetUploadedFileTxt , Is.EqualTo(fileName) , "Not equal");

        }
    }

    

}

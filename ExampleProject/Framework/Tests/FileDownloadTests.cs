using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;
using System.IO;

namespace ExampleProject.Framework.Tests
{
    internal class FileDownloadTests : BaseTest
    {
        private FileDownloadPage fileDownloadPage = new();
        private static readonly string fileName = testdata.GetValue<string>("fileDownload.fileName");
        private static readonly string filePath = testdata.GetValue<string>("fileDownload.folderPath") + fileName;
        private static readonly FileInfo downloadedFile = new(Path.GetFullPath(filePath));

        [Test]
        public void FileDownloadTest()
        {
            //mainPage.ClickNavigationLink("File Download");
            Assert.That(fileDownloadPage.IsFileDownloadLinkDisplayed(fileName), "not displayed");
            fileDownloadPage.ClickFileDownloadLink(fileName);
            Assert.That(FileUtils.IsFileExists(filePath), "file is not downloaded");

            
        }

        [TearDown]
        public void DeleteFile()
        {
            FileUtils.DeleteFileIfExists(downloadedFile);
        }
    }
}

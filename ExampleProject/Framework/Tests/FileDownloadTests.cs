using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;
using System.IO;

namespace ExampleProject.Framework.Tests
{    
    [AllureEpic("File system")]
    internal class FileDownloadTests : BaseTest
    {
        private FileDownloadPage fileDownloadPage = new();
        private static readonly string fileName = testdata.GetValue<string>("fileDownload.fileName");
        private static readonly string filePath = testdata.GetValue<string>("fileDownload.folderPath") + fileName;
        private static readonly FileInfo downloadedFile = new(Path.GetFullPath(filePath));

        [Test]
        [AllureSuite("Files tests")]       
        [AllureSeverity(SeverityLevel.trivial)]
        [AllureId(15)]
        [AllureLabel("Download", "super download file")]
        [AllureName("File download name name name")]
        public void FileDownloadTest()
        {
            AllureApi.Step(nameof(mainPage.ClickNavigationLink));
            mainPage.ClickNavigationLink("File Download");
            Assert.That(fileDownloadPage.IsFileDownloadLinkDisplayed(fileName),
                "Download link is not displayed");
            AllureApi.Step(nameof(fileDownloadPage.ClickFileDownloadLink));
            fileDownloadPage.ClickFileDownloadLink(fileName);
            Assert.That(FileUtils.IsFileExists(filePath), "File was not downloaded");
        }

        [TearDown]
        public void DeleteFile()
        {
            FileUtils.DeleteFileIfExists(downloadedFile);
        }
    }
}

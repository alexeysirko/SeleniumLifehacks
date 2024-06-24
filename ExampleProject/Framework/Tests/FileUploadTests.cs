namespace ExampleProject.Framework.Tests
{
    internal class FileUploadTests : BaseTest
    {
        private static readonly string fileName = testdata.GetValue<string>("fileUpload.fileName");
        private static readonly string filePath = testdata.GetValue<string>("fileUpload.filePath") + fileName;
    }
}

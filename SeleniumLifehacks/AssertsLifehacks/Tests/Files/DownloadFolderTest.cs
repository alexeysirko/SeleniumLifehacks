using System.Reflection;

namespace AssertsLifehacks.Tests.Files
{
    internal class DownloadFolderTest
    {
        const string MyProjectPathExample = "C:\\Users\\lesha\\OneDrive\\Documents\\GitHub\\SeleniumLifehacks\\SeleniumLifehacks\\AssertsLifehacks";
        const string FullPathExample = MyProjectPathExample + "\\Tests\\Files\\exampleFile.json";
        const string BinPathExample = MyProjectPathExample + "\\bin\\Debug\\net7.0\\Tests\\Files\\exampleFile.json";
        const string RelativePath = "Tests\\Files\\exampleFile.json";

        [Test]
        public void PathGetFullPath()
        {
            // Works only if you marked "Copy to output directory": true
            // Returns BinPathExample
            string binPathFromRelative = Path.GetFullPath(RelativePath);

            Assert.AreEqual(BinPathExample, binPathFromRelative);
        }

        [Test]
        public void BinPaths()
        {
            // Returns path of bin folder
            string getCurrentDirectory = Directory.GetCurrentDirectory();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string currentDirectory = Environment.CurrentDirectory;
            string assemblyDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

            // Bin folder path + file path
            string filePathInBin1 = Path.Combine(getCurrentDirectory, RelativePath);
            string filePathInBin2 = Path.Combine(baseDirectory, RelativePath);
            string filePathInBin3 = Path.Combine(currentDirectory, RelativePath);
            string filePathInBin4 = Path.Combine(Path.GetDirectoryName(assemblyDirectory), RelativePath);

            Assert.That(BinPathExample, Is.EqualTo(filePathInBin1).And.EqualTo(filePathInBin2).And.EqualTo(filePathInBin3).And.EqualTo(filePathInBin4));
        }

        [Test]
        public void Parent()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            // project folder path
            string csprojPath = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            // full file path in the project folder 
            string fullPath = Path.Combine(csprojPath, RelativePath);

            Assert.AreEqual(FullPathExample, fullPath);
        }
    }
}

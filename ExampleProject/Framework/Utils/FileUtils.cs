using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using System.IO;

namespace ExampleProject.Framework.Utils
{
    internal class FileUtils
    {
        protected static readonly JsonSettingsFile settings = new("config.json");

        public static bool IsFileExists(string filePath)
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => File.Exists(filePath));
            return File.Exists(filePath);
        }

        public static void DeleteFileIfExists(FileInfo fileName)
        {
          //to implement
        }
    }
}

using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Reflection;

namespace ExampleProject.Hooks
{
    internal static class Reporter
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        private static ExtentReports StartReporting()
        {
            if (extentReports != null)
                return extentReports;

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location + @"..\..\..\..\..\..\ExtentReportResults\");
            Directory.CreateDirectory(path);

            extentReports = new ExtentReports();
            ExtentSparkReporter sparkReports = new(path + "Spark.html");

            extentReports.AttachReporter(sparkReports);

            return extentReports;
        }

        public static void CreateFeature(string featureName)
        {
            extentTest = StartReporting().CreateTest<Feature>(featureName);
        }

        public static void CreateScenario(string scenarioName)
        {
            extentTest.CreateNode<Scenario>(scenarioName);
        }

        public static void AddStep(string gherkinKeyword, string name)
        {
            extentTest.CreateNode(new GherkinKeyword(gherkinKeyword), name).Pass();
        }

        public static void EndReporting()
        {
            extentReports.Flush();
        }

        public static void LogInfo(string info)
        {
            extentTest.Info(info);
        }

        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }

        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }

        public static void LogScreenshot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}

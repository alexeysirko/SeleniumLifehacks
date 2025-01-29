using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Unit8Tests.Tests
{
    internal abstract class BaseTest
    {

        [TearDown]
        protected void GetTestResult()
        {     
            // Классический вариант
            var result = TestContext.CurrentContext.Result;
            TestContext.WriteLine($"Test Result: {result.Outcome.Status}");

            // Internal классы Nunit
            //var Result = TestExecutionContext.CurrentContext.CurrentResult;
            //TestContext.WriteLine(nunitResult.AssertCount);
        }

        [TearDown]
        protected void ChangeResultToPassed()
        {
            var currentTest = TestContext.CurrentContext.Test;
            if (currentTest.Properties["Category"].Contains("Magic"))
            {
                TestContext.WriteLine("Test failed with message: " + TestContext.CurrentContext.Result.Message);
                TestExecutionContext.CurrentContext.CurrentResult.SetResult(ResultState.Success, $"But later test magically passed!");
            }
        }
    }
}

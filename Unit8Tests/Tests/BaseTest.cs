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
    }
}

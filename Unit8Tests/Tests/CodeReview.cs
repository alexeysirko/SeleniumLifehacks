
//        using NUnit.Framework;
//using Calculator.utils;
//using Calculator.windows;
//using TestStack.White;
//using System.Threading;


//namespace Calculator
//    {
//        [TestFixture]
//        public class CalculatorTest
//        {
//            private Application _app;
//            [SetUp]
//            public void StartApp()
//            {
//                LoggerUtil.InitLogger();
//                LoggerUtil.Log.Info("Test started");
//                ProcessesUtil.CloseAllProcessesByName(Settings.Default.processName);
//                _app = App.GetInstance().GetApplication();
//                LoggerUtil.Log.Info("Precondition completed");
//            }
//            [Test]
//            public void UiTest()
//            {
//                MainWindow mainWindow = new MainWindow(_app);
//                mainWindow.SelectMode("Standard");
//                mainWindow.EnterNumber(12);
//                Thread.Sleep(1000);
//                mainWindow.AddNumber(999);
//                Thread.Sleep(1000);
//                mainWindow.RememberResult();
//                mainWindow.EnterNumber(19);
//                mainWindow.PressAdd();
//                Thread.Sleep(1000);
//                mainWindow.GetNumberFromMemory();
//                mainWindow.PressEquals();
//                Assert.True("1030".Equals(mainWindow.GetResult()));
//            }
//            [TearDown]
//            public void Cleanup()
//            {
//                _app.Kill();
//                LoggerUtil.Log.Info("Test finished\n");
//            }
//        }
//    }
//}
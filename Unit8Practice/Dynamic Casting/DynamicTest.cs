using System.Runtime.InteropServices;

namespace Unit8Practice.Dynamic_Casting
{
    internal class DynamicTest
    {
        public static void DynamicLogic()
        {
            // Useful for interacting with COM objects, dynamic languages, or APIs that return objects of varying types.
            dynamic dynamicVariable = "Hello, World!";
            Console.WriteLine(dynamicVariable);

            // Runtime errors, hard to read
            dynamicVariable = 12345;
            Console.WriteLine(dynamicVariable);

            // Slow
            dynamicVariable = new { Name = "Alice", Age = 30 };
            Console.WriteLine(dynamicVariable.Name);
        }



        // To make it work you need to download the dll
        /// <summary>
        /// Import the CoInitialize function from the ole32.dll library. This function initializes the COM(Component object model) library for use by the calling thread
        /// </summary>
        /// <param name="pvReserved"> special initialization </param>
        [DllImport("ole32.dll")]
        private static extern int CoInitialize(IntPtr pvReserved);

        // Closes the COM library on the calling thread.
        // extern keyword is used primarily for calling unmanaged code using Platform Invocation Services (P/Invoke). This allows C# programs to call functions from native libraries (DLLs)
        [DllImport("ole32.dll")]
        private static extern void CoUninitialize();

        public static void DynamicExcelApp()
        {
            // Initialize the COM library for the current thread. IntPtr.Zero indicates that no special initialization is required.
            CoInitialize(IntPtr.Zero);

            // Example COM object usage
            dynamic excelApp = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            excelApp.Visible = true;
            excelApp.Workbooks.Add();

            // Clean up
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);

            CoUninitialize();
        }
    }
}

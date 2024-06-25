namespace Unit8Practice.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    internal class MyCustomDescriptionAttribute : Attribute
    {
        public string Description { get; }
        public int Version { get; }

        public MyCustomDescriptionAttribute(string description, int version)
        {
            Description = description;
            Version = version;
        }

        public void LogAttributeInfo()
        {
            Console.WriteLine($"Attribute Info: Description = {Description}, Version = {Version}");
        }
    }
}

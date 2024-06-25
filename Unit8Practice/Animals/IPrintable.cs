namespace Unit8Practice.Animals
{
    internal interface IPrintable
    {
        public void PrintInfo();
    }

    internal interface IDetailedPrintable : IPrintable
    {
        protected string Details { get; set; }
        public void PrintDetailedInfo()
        {
            Console.WriteLine($"Detailed information: {Details}");
        }
    }
}

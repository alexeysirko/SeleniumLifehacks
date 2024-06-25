namespace Unit8Practice.Delegates
{
    internal class Delegates
    {
        // Type that represents references to methods that have a particular parameter list and return type
        public delegate string GetEmotion(char endOfSentence);

        private static string GetHappyEmotion(char endOfSentence) => $"Happyyy :{endOfSentence}";
        private static string GetSadEmotion(char endOfSentence) => $"Saad :{endOfSentence}";

        public static void DelegatesLogic()
        {
            GetEmotion happyDelegate = new(GetHappyEmotion);
            GetEmotion sadDelegate = new(GetSadEmotion);

            Console.WriteLine($"Happy emotion: {happyDelegate(')')}");
            Console.WriteLine($"Sad emotion: {sadDelegate('(')}");

            GetEmotion combinedEmotionsDelegate = happyDelegate + sadDelegate;

            Delegate[] delegates = combinedEmotionsDelegate.GetInvocationList();
            foreach (Delegate delegator in delegates)
            {
                string combinedEmotion = delegator.DynamicInvoke('O').ToString();
                Console.WriteLine($"Combined emotion: {combinedEmotion}");
            }
        }
    }
}

namespace Unit8Practice.Patterns
{
    internal class AbstractFactory
    {
        // Абстрактный продукт A
        public interface IButton
        {
            void Click();
        }

        // Абстрактный продукт B
        public interface ITextBox
        {
            void Type();
        }


        // Конкретный продукт A1
        public class WindowsButton : IButton
        {
            public void Click()
            {
                Console.WriteLine("Windows Button Clicked");
            }
        }

        // Конкретный продукт A2
        public class MacButton : IButton
        {
            public void Click()
            {
                Console.WriteLine("Mac Button Clicked");
            }
        }


        // Конкретный продукт B1
        public class WindowsTextBox : ITextBox
        {
            public void Type()
            {
                Console.WriteLine("Typing in Windows TextBox");
            }
        }

        // Конкретный продукт B2
        public class MacTextBox : ITextBox
        {
            public void Type()
            {
                Console.WriteLine("Typing in Mac TextBox");
            }
        }


        // Фабрики
        public interface IGUIFactory
        {
            IButton CreateButton();
            ITextBox CreateTextBox();
        }


        public class WindowsFactory : IGUIFactory
        {
            public IButton CreateButton()
            {
                return new WindowsButton();
            }

            public ITextBox CreateTextBox()
            {
                return new WindowsTextBox();
            }
        }

        public class MacFactory : IGUIFactory
        {
            public IButton CreateButton()
            {
                return new MacButton();
            }

            public ITextBox CreateTextBox()
            {
                return new MacTextBox();
            }
        }


        public static class FactoryLogic
        {
            static void MainFactoryMethod()
            {
                IGUIFactory factory;

                // Создаем фабрику для Windows
                factory = new WindowsFactory();
                var winButton = factory.CreateButton();
                var winTextBox = factory.CreateTextBox();
                winButton.Click();
                winTextBox.Type();

                // Создаем фабрику для Mac
                factory = new MacFactory();
                var macButton = factory.CreateButton();
                var macTextBox = factory.CreateTextBox();
                macButton.Click();
                macTextBox.Type();
            }
        }
    }
}

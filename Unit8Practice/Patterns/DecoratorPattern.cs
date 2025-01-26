namespace Unit8Practice.Patterns
{
    internal class DecoratorPattern
    {
        // Интерфейс компонента
        public interface IComponent
        {
            void Operation();
        }

        // Конкретный компонент
        public class ConcreteComponent : IComponent
        {
            public void Operation()
            {
                Console.WriteLine("ConcreteComponent Operation");
            }
        }

        // Базовый декоратор
        public abstract class Decorator : IComponent
        {
            protected IComponent _component;

            public Decorator(IComponent component)
            {
                _component = component;
            }

            public virtual void Operation()
            {
                _component.Operation();
            }
        }

        // Конкретный декоратор A
        public class ConcreteDecoratorA : Decorator
        {
            public ConcreteDecoratorA(IComponent component) : base(component) { }

            public override void Operation()
            {
                base.Operation();
                Console.WriteLine("ConcreteDecoratorA Operation");
            }
        }

        // Конкретный декоратор B
        public class ConcreteDecoratorB : Decorator
        {
            public ConcreteDecoratorB(IComponent component) : base(component) { }

            public override void Operation()
            {
                base.Operation();
                AdditionalOperation();
            }

            private void AdditionalOperation()
            {
                Console.WriteLine("ConcreteDecoratorB Additional Operation");
            }
        }

        // Пример использования
        class DecoratorLogic
        {
            static void MainMethod()
            {
                IComponent component = new ConcreteComponent();
                IComponent decoratorA = new ConcreteDecoratorA(component);
                IComponent decoratorB = new ConcreteDecoratorB(decoratorA);

                decoratorB.Operation();
            }
        }
    }
}

namespace Unit8Practice.Patterns
{
    internal class Mediator
    {
        // Интерфейс посредника
        public interface IMediator
        {
            void Notify(object sender, string ev);
        }

        // Базовый компонент
        public abstract class BaseComponent
        {
            protected IMediator _mediator;

            public BaseComponent(IMediator mediator = null)
            {
                _mediator = mediator;
            }

            public void SetMediator(IMediator mediator)
            {
                _mediator = mediator;
            }
        }

        // Конкретный компонент A
        public class ComponentA : BaseComponent
        {
            public void DoA()
            {
                Console.WriteLine("Component A does A.");
                _mediator?.Notify(this, "A");
            }
        }

        // Конкретный компонент B
        public class ComponentB : BaseComponent
        {
            public void DoB()
            {
                Console.WriteLine("Component B does B.");
                _mediator?.Notify(this, "B");
            }
        }

        // Конкретный посредник
        public class ConcreteMediator : IMediator
        {
            private ComponentA _componentA;
            private ComponentB _componentB;

            public ConcreteMediator(ComponentA componentA, ComponentB componentB)
            {
                _componentA = componentA;
                _componentA.SetMediator(this);
                _componentB = componentB;
                _componentB.SetMediator(this);
            }

            public void Notify(object sender, string ev)
            {
                if (ev == "A")
                {
                    Console.WriteLine("Mediator reacts on A and triggers following operations:");
                    _componentB.DoB();
                }
                if (ev == "B")
                {
                    Console.WriteLine("Mediator reacts on B and triggers following operations:");
                    _componentA.DoA();
                }
            }
        }

        // Пример использования
        class MediatorLogic
        {
            static void Main()
            {
                ComponentA componentA = new ComponentA();
                ComponentB componentB = new ComponentB();
                new ConcreteMediator(componentA, componentB);

                componentA.DoA();
                componentB.DoB();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit8Practice.Patterns
{
    internal class FacadePattern
    {
        // Подсистема 1
        public class SubSystemOne
        {
            public void MethodOne()
            {
                Console.WriteLine("SubSystemOne: MethodOne");
            }
        }

        // Подсистема 2
        public class SubSystemTwo
        {
            public void MethodTwo()
            {
                Console.WriteLine("SubSystemTwo: MethodTwo");
            }
        }

        // Подсистема 3
        public class SubSystemThree
        {
            public void MethodThree()
            {
                Console.WriteLine("SubSystemThree: MethodThree");
            }
        }

        // Фасад
        public class Facade
        {
            private SubSystemOne _one;
            private SubSystemTwo _two;
            private SubSystemThree _three;

            public Facade()
            {
                _one = new SubSystemOne();
                _two = new SubSystemTwo();
                _three = new SubSystemThree();
            }

            public void MethodA()
            {
                Console.WriteLine("Facade: MethodA");
                _one.MethodOne();
                _two.MethodTwo();
            }

            public void MethodB()
            {
                Console.WriteLine("Facade: MethodB");
                _two.MethodTwo();
                _three.MethodThree();
            }
        }

        // Пример использования
        class Program
        {
            static void MainMethod()
            {
                Facade facade = new Facade();

                facade.MethodA();
                facade.MethodB();
            }
        }
    }
}

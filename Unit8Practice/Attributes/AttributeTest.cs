using System.Reflection;

namespace Unit8Practice.Attributes
{
    [MyCustomDescription("This is a class to test my", 1)]
    internal class AttributeTest
    {
        [MyCustomDescription("It's a method to test my attr", 25)]
        public void SomeMethod()
        {           
        }

        public static void AttributeLogic()
        {
            Type type = typeof(AttributeTest);
            object[] attributes = type.GetCustomAttributes(typeof(MyCustomDescriptionAttribute), false);

            foreach (MyCustomDescriptionAttribute attr in attributes)
            {
                attr.LogAttributeInfo();
            }

            MethodInfo method = type.GetMethod(nameof(SomeMethod));
            attributes = method.GetCustomAttributes(typeof(MyCustomDescriptionAttribute), false);

            foreach (MyCustomDescriptionAttribute attr in attributes)
            {
                attr.LogAttributeInfo();
            }
        }
    }
}

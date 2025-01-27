using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class DragAndDropTests : BaseDragAndDropTest
    {
        private DragAndDropPage _dragAndDropPage = new();

        [SetUp]
        public void GoToLink()
        {
            _browser.Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
        }

        [Test]
        public void DragAndDropTest()
        {
            const char SourceColumn = 'a';
            const char DestinationColumn = 'b';

            _dragAndDropPage.DragAndDropColumn(SourceColumn, DestinationColumn);

        }

    }
}

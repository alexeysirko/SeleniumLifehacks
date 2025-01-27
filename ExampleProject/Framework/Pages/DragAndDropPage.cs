using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ExampleProject.Framework.Pages
{
    internal class DragAndDropPage : Form
    {
        private RelativeBy ColumnLocator(char columnLetter) => RelativeBy.WithLocator(By.Id($"column-{columnLetter}"));
        private ILabel Column(char columnLetter) => ElementFactory.GetLabel(ColumnLocator(columnLetter), nameof(Column));

        public DragAndDropPage() : base(By.Id("columns"), nameof(DragAndDropPage))
        {
        }

        public void DragAndDropColumn(char sourceColumn, char destinationColumn)
        {
            var actions = new Actions(AqualityServices.Browser.Driver);

            var sourceColumnElement = Column(sourceColumn).GetElement();
            var destinationColumnElement = Column(destinationColumn).GetElement();

            actions.DragAndDrop(sourceColumnElement, destinationColumnElement)
                .Build()
                .Perform();
        }

        public bool IsColumnAtLeftSide(char expectedLeftColumn, char expectedRightColumn)
        {
            var leftColumnLocator = ColumnLocator(expectedLeftColumn).LeftOf(ColumnLocator(expectedRightColumn));

            return ElementFactory.GetLabel(leftColumnLocator, "left").State.WaitForDisplayed();
        }
    }
}

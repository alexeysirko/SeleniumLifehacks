using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Framework.Tests
{
    internal class BaseDragAndDropTest
    {
        protected Browser _browser;

        [SetUp]
        public void SetUp()
        {
            _browser = AqualityServices.Browser;
            _browser.Maximize();            
        }

        [TearDown]
        public void TearDown()
        {
            _browser.Quit();
        }
    }
}

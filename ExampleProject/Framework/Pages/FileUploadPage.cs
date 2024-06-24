using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Framework.Pages
{
    internal class FileUploadPage : Form
    {
        private const string PageName = "File Upload";
        private readonly IButton fileUploadBtn = ElementFactory.GetButton(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "File Upload")), "File Upload");
        private readonly ITextBox chooseFileTxb = ElementFactory.GetTextBox(By.Id("file-upload"), "Choose file button");
        private readonly IButton fileSubmitBtn = ElementFactory.GetButton(By.Id("file-submit"), "Submit file field");
        private readonly ILabel uploadedFileField = ElementFactory.GetLabel(By.Id("uploaded-files"), "Uploaded file field");


        public FileUploadPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }


        public void ClickFileUploadBtn() => fileUploadBtn.Click();
        public void SendKeysToFileToChooseFileTxb(string value) => chooseFileTxb.SendKeys(value);
        public void ClickFileSubmitBtn() => fileSubmitBtn.Click();
        public string GetNameOfUploadedFile() => uploadedFileField.Text;
    }
}

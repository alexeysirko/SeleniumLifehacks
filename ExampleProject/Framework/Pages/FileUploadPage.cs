using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Microsoft.VisualStudio.TestPlatform.Utilities;
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
        private const string PageName = "File Uploader";
       
        private ITextBox chooseFile = ElementFactory.GetTextBox(By.Id("file-upload"), "choose file");
        private IButton submitBtn = ElementFactory.GetButton(By.Id("file-submit"), "Submit Button");
        private ILabel uploadedFiles = ElementFactory.GetLabel(By.Id("uploaded-files"), "Uploaded files field");

        public FileUploadPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator , PageName)), PageName)
        {

        }

        
        public void SendKeysToChooseFile(string value) => chooseFile.SendKeys(value);

        public void ClickSubmitButton() => submitBtn.Click();

        public string GetUploadedFileTxt() => uploadedFiles.Text;
    }
}

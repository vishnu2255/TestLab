using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestLab.Pages
{
    public class TestPage
    {
        private readonly IWebDriver _driver;
        private const string Url = "https://formy-project.herokuapp.com/form";
        private readonly By _firstName = By.Id("first-name");
        private readonly By _lastName = By.Id("last-name");
        private readonly By _jobTitle = By.Id("job-title");
        private readonly By _education = By.Id("radio-button-2");
        private readonly By _gender = By.Id("checkbox-2");
        private readonly By _experienceSelect = By.Id("select-menu");
        private readonly By _datePicker = By.Id("datepicker");
        private readonly By _submitBtn = By.XPath("//*[@role='button']");
        private readonly By _msg = By.XPath("//*[@role='alert']");

        public TestPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(Url);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        private void SetUserDetails(string firstname, string lastname, string jobtitle)
        {
            _driver.FindElement(_firstName).SendKeys(firstname);
            _driver.FindElement(_lastName).SendKeys(lastname);
            _driver.FindElement(_jobTitle).SendKeys(jobtitle);
        }

        private void SelectGender()
        {
            _driver.FindElement(_gender).Click();
        }

        private void SelectExperience(string exp)
        {
            var experienceElement = _driver.FindElement(_experienceSelect);
            var selectElement = new SelectElement(experienceElement);
            selectElement.SelectByText(exp);
        }

        private void SelectEducation()
        {
            _driver.FindElement(_education).Click();
        }

        private void SelectDate(string date)
        {
            _driver.FindElement(_datePicker).SendKeys(date);
        }

        public string GetDate()
        {
            var element = _driver.FindElement(_datePicker);
            var js = (IJavaScriptExecutor)_driver;
            return (string)js.ExecuteScript("return arguments[0].value", element);
        }

        public string GetMessage()
        {
            return _driver.FindElement(_msg).Text;
        }

        private void ClickSubmitButton()
        {
            _driver.FindElement(_submitBtn).Click();
        }

        public void FillForm(string firstname, string lastname, string jobtitle, string experience, string date)
        {
            NavigateToPage();
            SetUserDetails(firstname, lastname, jobtitle);
            SelectEducation();
            SelectGender();
            SelectExperience(experience);
            SelectDate(date);
        }

        public void SubmitForm()
        {
            ClickSubmitButton();
        }
    }
}
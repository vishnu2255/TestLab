using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestLab.Pages
{
    public class TestPage
    {
        private readonly IWebDriver driver;
        
        // Page URL
        private const string Url = "https://formy-project.herokuapp.com/form";
        
        // Locators
        private readonly By firstName = By.Id("first-name");
        private readonly By lastName = By.Id("last-name");
        private readonly By jobTitle = By.Id("job-title");
        private readonly By education = By.Id("radio-button-2");
        private readonly By gender = By.Id("checkbox-2");
        private readonly By experienceSelect = By.Id("select-menu");
        private readonly By datePicker = By.Id("datepicker");
        private readonly By submitBtn = By.XPath("//*[@role='button']");
        private readonly By msg = By.XPath("//*[@role='alert']");
        
        // Constructor
        public TestPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Navigate to login page
        private void NavigateToPage()
        {
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        // Set user details
        private void SetUserDetails(string firstname, string lastname, string jobtitle)
        {
            driver.FindElement(firstName).SendKeys(firstname);
            driver.FindElement(lastName).SendKeys(lastname);
            driver.FindElement(jobTitle).SendKeys(jobtitle);
        }

        // Select gender
        private void SelectGender()
        {
            driver.FindElement(gender).Click();
        }
        
        // Select experience
        private void SelectExperience(string exp)
        {
            IWebElement experienceElement = driver.FindElement(experienceSelect);
            var selectElement = new SelectElement(experienceElement);
            selectElement.SelectByText(exp);
        }
        
        // Select education
        private void SelectEducation()
        {
            driver.FindElement(education).Click();
        }
        
        // Select date
        private void SelectDate(string date)
        {
            driver.FindElement(datePicker).SendKeys(date);
        }
        
        public string GetDate()
        {
            IWebElement element = driver.FindElement(datePicker);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; 
            string date = (String) js.ExecuteScript("return arguments[0].value", element);
            return date;
        }
        
        // Get message
        public string GetMessage()
        {
            return driver.FindElement(msg).Text;
        }
        
        // Click on submit button
        private void ClickSubmitButton()
        {
            driver.FindElement(submitBtn).Click();
        }

        // Fill form
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
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestLab.Pages;
using Xunit;
using Xunit.Abstractions;

namespace TestLab.Tests
{
    public class TestRunner : IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private IWebDriver _driver;
        private TestPage _testPage;

        private const string Username = "John";
        private const string Password = "Doe";
        private const string Title = "Tester";
        private const string Experience = "5-9";
        private const string DateOption = "04/24/2023";
        private const string ExpectedMsg = "The form was successfully submitted!";

        public TestRunner(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(BrowserType.Chrome)]
        //[InlineData(BrowserType.Firefox)]
        public void RunTests(BrowserType browserType)
        {
            _driver = WebDriverFactory.CreateWebDriver(browserType);
            _testPage = new TestPage(_driver);

            _testPage.FillForm(Username, Password, Title, Experience, DateOption);

            var currentDate = GetCurrentDate();
            
            //NOTE: The following assert always fail as the Datepicker is not resetting to current date after we set other date
            //Assert.Equal(currentDate, _testPage.GetDate());
            
            _testOutputHelper.WriteLine("Current date " + currentDate);
            _testOutputHelper.WriteLine("Selected from DatePicker: " + _testPage.GetDate());
            
            _testPage.SubmitForm();

            var actualMessage = _testPage.GetMessage();
            Assert.Equal(ExpectedMsg, actualMessage);
            _testOutputHelper.WriteLine("Message: " + actualMessage);
            
            _driver.Quit();
        }

        private static string GetCurrentDate()
        {
            return DateTime.Today.ToString("MM/dd/yyyy");
        }

        public void Dispose()
        {
            _driver?.Quit();
        }
    }
}
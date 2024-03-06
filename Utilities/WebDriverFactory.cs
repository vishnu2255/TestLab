using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

public enum BrowserType
{
    Chrome,
    Firefox
}

public static class WebDriverFactory
{
    public static IWebDriver CreateWebDriver(BrowserType browserType)
    {
        switch (browserType)
        {
            case BrowserType.Chrome:
                return CreateChromeDriver();
            case BrowserType.Firefox:
                return CreateFirefoxDriver();
            default:
                throw new WebDriverException($"Unsupported browser type: {browserType}");
        }
    }

    private static IWebDriver CreateChromeDriver()
    {
        // Specify additional options as needed
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("start-maximized");
        options.AddArgument("disable-infobars");
        options.AddArgument("--disable-extensions");
        
        return new ChromeDriver(options);
    }

    private static IWebDriver CreateFirefoxDriver()
    {
        IWebDriver driver = new FirefoxDriver();     
        driver.Manage().Window.Maximize();
        return driver;
    }
}
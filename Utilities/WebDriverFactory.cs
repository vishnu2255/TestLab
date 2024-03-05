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
        // Specify additional options as needed
        FirefoxOptions options = new FirefoxOptions();
        options.AddArgument("--start-maximized");
        var path = "/usr/local/bin";
        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path);

        // Create a ChromeDriver instance with the service and options
        //IWebDriver driver = new ChromeDriver(service, options);*/

        // Now you can use the ChromeDriver instance for automation
        /*options.AddArgument("disable-infobars");
        options.AddArgument("--disable-extensions");*/
        
        return new FirefoxDriver(service, options);
    }
}
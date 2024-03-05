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
        /*FirefoxOptions options = new FirefoxOptions();
        options.AddArgument("--start-maximized");
        var path = "/Users/vishnu.patlolla/Downloads/gecko";
        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path);
        service.FirefoxBinaryPath = "/Users/vishnu.patlolla/Applications/Firefox.exe";
        
        return new FirefoxDriver(service, options);*/
        return new FirefoxDriver();
    }
}
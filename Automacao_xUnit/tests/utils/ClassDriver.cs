using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using Xunit;

namespace Automacao_xUnit.tests.steps
{
    class ClassDriver : IDisposable
    {
        private static ClassDriver classDriver;
        private IWebDriver driver;

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

            set
            {
                driver = value;
            }
        }

        private ClassDriver()
        {

        }

        public static ClassDriver GetInstance()
        {
            if (classDriver == null)
            {
                classDriver = new ClassDriver();
            }
            return classDriver;
        }

        public void StartDriver(string typeBrowser)
        {
            var currentPath = Directory.GetCurrentDirectory();
            string path = $"{currentPath}/../../../WebDriverLinux";


            //if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            //{
            //    path = $"{currentPath}\\..\\..\\..\\WebDriverWindows";
            //}
            //else
            //{
            //    path = $"{currentPath}/../../../WebDriverLinux";
            //}

            //"C:\Users\leonardo.barcellos\source\repos\Teste\Automacao_xUnit_Fundacred\WebDriverWindows\chromedriver.exe"

            switch (typeBrowser)
            {
                case "C":
                    Driver = new ChromeDriver(path);
                    break;

                case "I":
                    Driver = new InternetExplorerDriver();
                    break;

                case "F":                                     
                    Driver = new FirefoxDriver();
                    break;

                case "E":
                    Driver = new EdgeDriver();
                    break;

                case "H":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments(path, "--window-size=1800,2000", "--headless", "--disable-gpu", "--no-sandbox");
                    Driver = new ChromeDriver(path, options);
                    break;

                default:
                    Driver = new ChromeDriver(path);
                    break;
            }

            Driver.Manage().Window.Maximize();
        }

        public void QuitDriver()
        {
            Driver.Quit();
        }

        public void Dispose()
        {
            classDriver.Dispose();
        }

        [CollectionDefinition("tests")]
        public class IntegrationTestCollection : ICollectionFixture<ClassDriver>
        {
            // Intentionally left blank.
            // This class only serves as an anchor for CollectionDefinition.
        }
    }
}

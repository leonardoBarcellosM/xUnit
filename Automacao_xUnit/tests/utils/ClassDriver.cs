using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;

namespace Automacao_Funcional.tests.steps
{
    class ClassDriver
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
            string path = "";
            

            if(Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                path = $"{currentPath}\\..\\..\\..\\WebDriverWindows";
            }
            else
            {
                path = $"{currentPath}/../../../WebDriverLinux";
            }

            //"C:\Users\leonardo.barcellos\source\repos\Teste\Automacao_Funcional_Fundacred\WebDriverWindows\chromedriver.exe"

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
                    driver = new ChromeDriver(path, options);
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
    }
}

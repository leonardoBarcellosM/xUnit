using OpenQA.Selenium;
using System;
using System.ComponentModel;
using System.Threading;
using Xunit;

namespace Automacao_xUnit.tests.steps
{
    [Collection("tests")]
    class AcessPageActions : AccessElementsMap
    {
        private ClassUtilities util = new ClassUtilities();

        ClassDriver fixture;

        public AcessPageActions()
        {
        }

        public AcessPageActions(ClassDriver fixture)
        {
            this.fixture = fixture;
        }

        public bool AccessPage(string url)
        {
            bool _result = false;
            try
            {
                ClassDriver.GetInstance().Driver.Navigate().GoToUrl(url);
                _result = true;
            }
            catch (Win32Exception w)
            {
                Console.WriteLine(w.Message);
                Console.WriteLine(w.ErrorCode.ToString());
                Console.WriteLine(w.NativeErrorCode.ToString());
                Console.WriteLine(w.StackTrace);
                Console.WriteLine(w.Source);
                Exception e = w.GetBaseException();
                Console.WriteLine(e.Message);
            }
            return _result;
        }


        public bool ValidAccessPage()
        {
            bool _result = false;
            try
            {
                IWebElement LogoHome = ClassDriver.GetInstance().Driver.FindElement(By.XPath("//div//a[@class='logo']"));
                util.WaitForElementVisible(LogoHome, 25);
                if (LogoHome.Displayed)
                {
                    _result = true;
                }
                else
                {

                }
            }
            catch (Exception)
            {
                ClassInfo.GetInstance().LogMessage = "Error";
            }
            return _result;
        }

        public bool ValidarAcessoIes()
        {
            bool _result = false;
            try
            {
                Thread.Sleep(10000);
                IWebElement formLogin = ClassDriver.GetInstance().Driver.FindElement(By.Id("formLogin"));
                util.WaitForElementVisible(formLogin, 15);
                if (formLogin.Displayed)
                {
                    _result = true;
                }
                else
                {

                }
            }
            catch (Exception)
            {
                ClassInfo.GetInstance().LogMessage = "Error";
            }
            return _result;
        }
    }
}

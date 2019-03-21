using OpenQA.Selenium;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace Automacao_Funcional.tests.steps
{
    class ClassUtilities
    {
        private IJavaScriptExecutor js;
        private string screenshots;
        private int Cont = 0;

        public bool WaitForElementVisible(IWebElement element, int timeoutSecond)
        {
            int count = 0;

            do
            {
                try
                {
                    return element.Displayed && element.Enabled;
                }
                catch (Exception)
                {
                    Thread.Sleep(250);
                    count++;
                }

            } while (count < timeoutSecond * 4);

            return false;

        }


        public void ScrollElementoPage(IWebElement element)
        {
            try
            {

                Point point = new Point();

                if (element != null)
                {
                    point = element.Location;
                    IJavaScriptExecutor js = ClassDriver.GetInstance().Driver as IJavaScriptExecutor;

                    js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

                }
            }
            catch (Exception)
            {
            }
        }


        public void ScrollPage(int num)
        {
            int scroll = num * 300;

            js = (IJavaScriptExecutor)ClassDriver.GetInstance().Driver;
            js.ExecuteScript("window.scrollBy(0, "+ scroll +")", "");

        }


        internal void ClickJS()
        {
            throw new NotImplementedException();
        }


        internal void WaitForElementVisible(IWebElement nameProduct)
        {
            throw new NotImplementedException();
        }


        public void SendKeyJS(IWebElement element, string value)
        {
            try
            {
                IJavaScriptExecutor js = ClassDriver.GetInstance().Driver as IJavaScriptExecutor;
                js.ExecuteScript("arguments[0].setAttribute('value', '" + value + "')", element);
            }
            catch (Exception)
            {

            }

        }


        public class Credentials
        {
            public string Cpf { get; set; }
            public string Senha { get; set; }
        }


        public string MascaraCpf(string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        //Pegar conteúdo de uma variável Local
        public static String getItemFromLocalStorage(String key)
        {
            IJavaScriptExecutor js = ClassDriver.GetInstance().Driver as IJavaScriptExecutor;

            return (String)js.ExecuteScript(String.Format(
                "return window.localStorage.getItem('tokenPES');", key));
        }


        public void ClickJS(IWebElement element)
        {
            try
            {
                IJavaScriptExecutor js = ClassDriver.GetInstance().Driver as IJavaScriptExecutor;
                js.ExecuteScript("arguments[0].click()", element);
            }
            catch (Exception)
            {

            }
        }


        public void HoverMenu(IWebDriver driver, IWebElement element)
        {
            try
            {
                string mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover', true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject) { arguments[0].fireEvent('onmouseover');}";
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript(mouseOverScript, element);

            }
            catch (Exception)
            {

            }
        }


        public void ScreenshotPrepare()
        {
            screenshots = @"C:\Users\leonardo.barcellos\Desktop\Screenshots\";
            CultureInfo cult = new CultureInfo("pt-BR");
            string dta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", cult);
            Screenshot(ClassDriver.GetInstance().Driver, screenshots + "ComeceAgora_" + Cont++ + ".png");
        }


        public void Screenshot(IWebDriver driver, string screenshotPasta)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotPasta, ScreenshotImageFormat.Png);
        }


        internal void Screenshot(IWebDriver driver, object p)
        {
            throw new NotImplementedException();
        }


        public static string PegarDataHora()
        {
            CultureInfo cult = new CultureInfo("pt-BR");
            string dta = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss", cult);

            return dta;
        }

        
        public string GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();
            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            semente = semente + resto;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            semente = semente + resto;
            return semente;
        }


        public string GerarRg()
        {
            Random random = new Random();
            string rg = random.Next(10000, 99999).ToString();
            string rg2 = random.Next(10000, 99999).ToString();
            rg = rg + rg2;
            return rg;
        }


        public string GerarNumRandom()
        {
            Random random = new Random();
            string numRandom = random.Next(100000, 999999).ToString();
            return numRandom;
        }


        //public void ClickJS(IWebElement element)
        //{
        //    try
        //    {
        //        // this.HigthLine(element, true);
        //        IJavaScriptExecutor executor = (IJavaScriptExecutor)ClassDriver.GetInstance().Driver;
        //        executor.ExecuteScript("arguments[0].click();", element);

        //    }
        //    catch (Exception) { }

        //}

    }
}

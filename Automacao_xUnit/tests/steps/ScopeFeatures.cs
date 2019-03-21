using TechTalk.SpecFlow;

namespace Automacao_Funcional.tests.steps
{
    [Binding]
    class ScopeFeatures
    {
       
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string dataHora = ClassUtilities.PegarDataHora();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureInfo featureInfo)
        {
            string typeBrowser = featureInfo.Title.Contains("-") ? featureInfo.Title.Split('-')[0] : null;
            ClassDriver.GetInstance().StartDriver(typeBrowser);
        }

        [BeforeScenario]
        public static void BeforeScenario(FeatureInfo featureInfo)
        {
       
        }

        [BeforeStep]
        public static void BeforeStep()
        {

        }

        [AfterStep]
        public static void AfterStep()
        {
            
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //Assert.IsTrue(ClassInfo.GetInstance().ResultScenario, ClassInfo.GetInstance().LogMessage, null);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            ClassDriver.GetInstance().QuitDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            
        }           
    }
}

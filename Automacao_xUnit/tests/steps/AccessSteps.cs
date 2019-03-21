using TechTalk.SpecFlow;
using Xunit;

namespace Automacao_Funcional.tests.steps
{
    [Binding]
    public class AccessSteps
    {
        private AcessPageActions pageAction = new AcessPageActions();
        //private FilaDeTrabalhoActions Fila = new FilaDeTrabalhoActions();

        [Given(@"Acessar o endereco ""(.*)""")]
        public void GivenAcessarOEndereco(string url)
        {
            var result = pageAction.AccessPage(url);

                Assert.True(result, "Erro ao acessar a URL -> " + url);
        }
        
        [Then(@"Validar o carregamento")]
        public void ThenValidarOCarregamentoComSucesso()
        {
            var result = pageAction.ValidAccessPage();

            Assert.True(result, "Erro ao acessar a endereço solicitado");
        }
       
    }
}

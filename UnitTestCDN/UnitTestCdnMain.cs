using CandidateTesting.PedroViniciusRodriguesFurlan.TextGenerator;
using CandidateTesting.PedroViniciusRodriguesFurlan.WbClientUtils;
using System;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Extensions.Ordering;

namespace UnitTestCDN
{
    
    public class UnitTestCdnMain
    {
        private string _CaminhoProjeto = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Fact , Order(1)]
        public void ChamarMetodoWebClient()
        {   
            var test_get_data = WebClientUtils.GetDataURL("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt");
            Assert.NotEmpty(test_get_data);
        }


        [Fact, Order(2)]
        public void GerarRelatorioTestLinhaUnica()
        {
           
            string caminhoSalvar = String.Format(@"{0}\TestRelatorioLinhaUnica.txt", _CaminhoProjeto);
            TextGeneratorUtils textUtils = new TextGeneratorUtils(caminhoSalvar);
           
            bool geradoRelatorio = textUtils.GenerateArquivoTXT("312|200|HIT|\"GET / robots.txt HTTP / 1.1\"|100.2");

            Assert.True(geradoRelatorio);
        }



        [Fact, Order(3)]
        public void GerarRelatorioProcessoCompleto()
        {
          
            string caminhoSalvar = String.Format(@"{0}\TestProcessoCompleto.txt", _CaminhoProjeto);
            string  valueContent = WebClientUtils.GetDataURL("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt");
            TextGeneratorUtils textUtils = new TextGeneratorUtils(caminhoSalvar);
            bool geradoRelatorio = textUtils.GenerateArquivoTXT(valueContent);

            Assert.True(geradoRelatorio);
        }

    }
}

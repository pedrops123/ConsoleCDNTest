using System;
using System.Net;

namespace CandidateTesting.PedroViniciusRodriguesFurlan.WbClientUtils {
     /// <summary>
     /// Classe utils do web client.  
     /// </summary>
    public static class WebClientUtils {

        /// <summary>
        /// Função para coletar dados em texto de uma url
        /// </summary>
        /// <param name="url"> Parametro url que vai definir de onde o web client vai retirar as informações. </param>
        public static string GetDataURL(string url){
            string dataWebSite = "";
            try
            {
                WebClient cli = new WebClient();  
                dataWebSite = cli.DownloadString(url).Trim();
                
            }
            catch(Exception e){
                Console.WriteLine($"Ocorreu um erro ao tentar coletar os dados base , segue detalhes abaixo : \n \n {e.ToString()}");            
            }
            return dataWebSite;
        }



    }

}
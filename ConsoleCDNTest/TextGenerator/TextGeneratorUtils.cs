using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CandidateTesting.PedroViniciusRodriguesFurlan.TextGenerator {
     /// <summary>
     /// Classe utils de criação arquivo de  texto  
     /// </summary>
    public class TextGeneratorUtils { 

        private string _CaminhoArquivoTxt = "";

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="caminhoEscolhido"> Parametro  que define o caminho do arquivo a ser criado </param>
        public TextGeneratorUtils(string caminhoEscolhido)
        {
            this._CaminhoArquivoTxt = caminhoEscolhido;
        }


        /// <summary>
        /// Function de criação do arquivo txt
        /// </summary>
        /// <param name="data"> Parametro dos dados coletados pelo WebClient </param>
        public bool GenerateArquivoTXT(string data){
            try
            {   
                if(File.Exists(_CaminhoArquivoTxt)){
                    File.Delete(_CaminhoArquivoTxt);
                    File.Create(_CaminhoArquivoTxt).Dispose();
                }
                else 
                {
                    File.Create(_CaminhoArquivoTxt).Dispose();
                }

               List<string> linhas = data.Split("\r\n").ToList();

               using(StreamWriter wr = new StreamWriter(_CaminhoArquivoTxt)){
                  wr.WriteLine($"#Version: 1.0");
                  wr.WriteLine($"#Date: { String.Format("{0}/{1}/{2}  {3}:{4}:{5}", DateTime.Now.Day , DateTime.Now.Month , DateTime.Now.Year , DateTime.Now.Hour , DateTime.Now.Minute , DateTime.Now.Millisecond) }");
                  wr.WriteLine("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");
                  foreach(string linha in linhas){
                      var splitContent = linha.Trim().Split("|");
                      wr.WriteLine(String.Format("\"MINHA CDN\" {0} {1} {2} {3} {4} {5}", splitContent[3].Split("/")[0].Split('"')[1] , splitContent[1] , splitContent[3].Split(" ")[1], splitContent[4].Split('.')[0] , splitContent[0],  splitContent[2] ));
                  }
               }
            }
            catch(Exception e){
                throw e;
            }

            return true;
        } 


    }
}
using System;
using CandidateTesting.PedroViniciusRodriguesFurlan.WbClientUtils;
using CandidateTesting.PedroViniciusRodriguesFurlan.TextGenerator;
using System.Linq;

namespace CandidateTesting.PedroViniciusRodriguesFurlan
{

    /// <summary>
    /// Classe principal do sistema
    /// </summary>
    class ConsoleLeitorCdnMain
    { 
        /// <summary>
        /// Função main do programa
        /// </summary>
        static void Main(string[] args)
        {
            topSystem:;
            Console.WriteLine("Comandos disponiveis para uso : \n \n * Convert \n ");
            var value =  Console.ReadLine().ToString();
            var splitCommand = value.Split(' ');

            if(splitCommand.ToList().Count() != 3){
                Console.WriteLine("Sintaxe incorreta , favor incluir o comando na seguinte sintaxe : \n \n convert url_data caminho_arquivo");
                goto topSystem;
            }

            bool resultValidaCommand = splitCommand[0].Trim().ToLower().Contains("convert");
            bool resultValidaUrl =  !String.IsNullOrEmpty(splitCommand[1].ToString());
            bool resultValidaCaminho =  !String.IsNullOrEmpty(splitCommand[2].ToString());

            if(resultValidaCommand && resultValidaUrl && resultValidaCaminho)
            {
                var data = WebClientUtils.GetDataURL(splitCommand[1]);
                TextGeneratorUtils txtGen = new TextGeneratorUtils(splitCommand[2]);
                var gerado =  txtGen.GenerateArquivoTXT(data);

                if(gerado){
                    Console.WriteLine($"Arquivo gerado com sucesso no caminho: { splitCommand[2] }");
                }

            }
            else
            {
                Console.WriteLine("Comando inexistente , favor incluir somente os comando disponiveis.");
                goto topSystem;
            }   
            
            goto topSystem;
        }
    }
}

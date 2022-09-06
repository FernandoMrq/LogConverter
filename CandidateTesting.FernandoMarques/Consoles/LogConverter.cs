using System;
using System.IO;

namespace CandidateTesting.FernandoMarques.Consoles
{
    internal class LogConverter
    {
        static void Main(string[] args)
        {
            while (StayOpen())
            {
                MakeDialogMenu();
                var url = GetURL();
                ValidateURL(url);
                var file = DownloadLog(url);
                var newFile = ConvertLog(file);
                var result = SaveNewFile(newFile);
            }

            Console.WriteLine("Não está pronto");
        }

        private static bool SaveNewFile(Stream newFile)
        {
            throw new NotImplementedException();
        }

        private static Stream ConvertLog(Stream file)
        {
            throw new NotImplementedException();
        }

        private static Stream DownloadLog(string url)
        {
            throw new NotImplementedException();
        }

        //Inerente ao console
        private static bool StayOpen()
        {
            Clear();
            throw new NotImplementedException();
        }

        //Precisa existir? | Inerente ao console
        private static string GetURL()
        {
            return Console.ReadLine();
        }

        //Inerente a regra
        private static bool ValidateURL(string url)
        {
            //Métodos de validação de URL
            throw new NotImplementedException();
        }

        //Precisa existir? | Inerente ao console
        private static void Clear()
        {
            Console.Clear();
        }

        //Inerente ao menu
        private static void MakeDialogMenu()
        {
            Console.WriteLine("This program will help you to get the log with new format. \n" +
                "Type de url for log extract:");
        }

    }
}

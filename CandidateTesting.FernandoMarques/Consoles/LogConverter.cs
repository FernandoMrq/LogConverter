using System;

namespace CandidateTesting.FernandoMarques.Consoles
{
    internal class LogConverter
    {
        static void Main(string[] args)
        {
            while (StayOpen())
            {
                Clear();
                var url = GetURL();
            }

            Console.WriteLine("Não está pronto");
        }

        //Inerente ao console
        private static bool StayOpen()
        {
            throw new NotImplementedException();
        }

        //Precisa existir? | Inerente ao console
        private static string GetURL()
        {
            string url = "";

            //Tem de ficar aqui?
            if (!ValidaUrl(url))
                throw new Exception("URL not valid");

            throw new NotImplementedException();
        }

        //Inerente a regra
        private static bool ValidaUrl(string url)
        {
            throw new NotImplementedException();
        }

        //Precisa existir? | Inerente ao console
        private static void Clear()
        {
            Console.Clear();
        }

        //private static void 
    }
}

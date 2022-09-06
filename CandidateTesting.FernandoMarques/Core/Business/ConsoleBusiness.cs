using CandidateTesting.FernandoMarques.Core.Domain.Business;
using System;

namespace CandidateTesting.FernandoMarques.Core.Business
{
    public class ConsoleBusiness : IConsoleBusiness
    {
        public string GetDestinationPath(string userInput)
        {
            throw new NotImplementedException();
        }

        public string GetURL(string userInput)
        {
            return Console.ReadLine();
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public void MakeDialogMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "This program will help you to get the log with AGORA format.\n" +
                "Type de url for log extract:"
            );
        }

        public void SendMalformedPathMessage()
        {
            throw new NotImplementedException();
        }

        public void SendMalformedURLMessage()
        {
            Console.WriteLine("Malformed URL, please verify.");
        }

        public void SendResultMessage(string newFileName)
        {
            Console.Clear();

            if (!string.IsNullOrWhiteSpace(newFileName))
            {
                Console.WriteLine(string.Format("The file {0} have not been saved.", newFileName));
                return;
            }

            Console.WriteLine(string.Format("The file {0} have been saved.", newFileName));

        }

        public bool StayOpen()
        {
            Console.WriteLine("Press c to close and any key to continue:");//TODO acertar com resource
            if (Console.ReadKey().KeyChar == 'c')
                return false;
            return true;
        }
    }
}

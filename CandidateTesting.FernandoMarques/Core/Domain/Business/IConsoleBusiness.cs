namespace CandidateTesting.FernandoMarques.Core.Domain.Business
{
    public interface IConsoleBusiness
    {
        public string GetURL(string userInput);
        public string GetDestinationPath(string userInput);
        public string GetUserInput();
        public void MakeDialogMenu();
        public void SendMalformedURLMessage();
        public void SendMalformedPathMessage();
        public void SendResultMessage(string newFileName);
        public bool StayOpen();
    }
}

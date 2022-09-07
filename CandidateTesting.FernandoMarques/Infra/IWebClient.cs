namespace CandidateTesting.FernandoMarques.Infra
{
    public interface IWebClient
    {
        byte[] DownloadData(string address);
    }
}

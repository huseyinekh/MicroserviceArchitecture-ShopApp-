namespace WebApp_.Services.Intefaces
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}

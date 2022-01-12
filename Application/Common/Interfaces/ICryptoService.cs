namespace Application.Common.Interfaces
{
    public interface ICryptoService
    {
        string Encrypt(string data);
        string Decrypt(string data);
    }
}

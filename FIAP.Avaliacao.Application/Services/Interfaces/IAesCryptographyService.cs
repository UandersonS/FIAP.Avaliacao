namespace FIAP.Avaliacao.Application.Services.Interfaces
{
    public interface IAesCryptographyService
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
}

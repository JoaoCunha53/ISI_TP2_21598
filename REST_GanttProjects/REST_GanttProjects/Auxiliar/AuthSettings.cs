using System.Security.Cryptography;
namespace AuthCore.Helpers;

public static class AuthSettings
{
    public static string PrivateKey { get; set; } = GeraKey(256);

    #region GeraKey
    /// <summary>
    /// Gerar a chave.
    /// </summary>
    /// <returns>Devolve a chave gerada.</returns>
    public static string GeraKey(int nBytes)
    {
        Aes aesAlgorithm = Aes.Create();
        aesAlgorithm.KeySize = 256;
        aesAlgorithm.GenerateKey();
        string keyBase64 = Convert.ToBase64String(aesAlgorithm.Key);
        return keyBase64;
    }
    #endregion
}
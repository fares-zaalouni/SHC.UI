
using SHC.UI.Shared.Security;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace SHC.UI.Windows.Security;

public class CredentialStorage : ICredentialStorage
{
    private readonly string _tokenFilePath;
    public CredentialStorage()
    {
        _tokenFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SHC",
                "refreshToken.dat");
    }
    public void ClearToken()
    {
        try
        {
            if (File.Exists(_tokenFilePath))
            {
                File.Delete(_tokenFilePath); // Delete the token file
            }
        }
        catch (IOException)
        {
            // Handle file access errors (e.g., file in use)
            // Log the error if needed
        }
    }

    public string? GetToken()
    {
        try
        {
            if (!File.Exists(_tokenFilePath))
                return null;

            // Read encrypted bytes
            byte[] encryptedBytes = File.ReadAllBytes(_tokenFilePath);
            // Decrypt using DPAPI
            byte[] tokenBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(tokenBytes);
        }
        catch (CryptographicException)
        {
            // Handle decryption failure (e.g., user credentials changed)
            return null;
        }
    }

    public void StoreToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            throw new ArgumentNullException(nameof(token));

        Directory.CreateDirectory(Path.GetDirectoryName(_tokenFilePath));

        byte[] tokenBytes = Encoding.UTF8.GetBytes(token);
        byte[] encryptedBytes = ProtectedData.Protect(tokenBytes, null, DataProtectionScope.CurrentUser);
        File.WriteAllBytes(_tokenFilePath, encryptedBytes);
    }
}

using Application.Common.Interfaces;
using Domain.Options;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Security
{
    public class CryptoService : ICryptoService
    {
        private readonly IOptions<SecurityOptions> _options;

        public CryptoService(IOptions<SecurityOptions> options) => _options = options;

        public string Decrypt(string data)
        {
            var buffer = Convert.FromBase64String(data);

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_options.Value.Key);
            aes.IV = new byte[16];

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new MemoryStream(buffer);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }

        public string Encrypt(string data)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_options.Value.Key);

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using StreamWriter streamWriter = new(cryptoStream);
            streamWriter.Write(data);

            byte[] inArray = memoryStream.ToArray();
            return Convert.ToBase64String(inArray);
        }
    }
}

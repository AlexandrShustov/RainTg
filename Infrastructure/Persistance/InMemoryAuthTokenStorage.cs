using Application.Common.Interfaces;
using System.Collections.Concurrent;

namespace Infrastructure.Persistance
{
    public class InMemoryAuthTokenStorage : IAuthTokenStorage
    {
        private readonly ICryptoService _cryptoService;
        private ConcurrentDictionary<long, string> _tokensById = new ConcurrentDictionary<long, string>();

        public InMemoryAuthTokenStorage(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public Task AssignTo(long chatId, string token)
        {
            var encoded = _cryptoService.Encrypt(token);
            _tokensById.AddOrUpdate(chatId, encoded, (x, y) => encoded);
            return Task.CompletedTask; 
        }

        public Task<string> GetBy(long chatId)
        {
            if (_tokensById.TryGetValue(chatId, out var value))
                return Task.FromResult(_cryptoService.Decrypt(value));

            return Task.FromResult(string.Empty);
        }
    }
}

using Auth.Domain.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Caching
{
    public class RedisRefreshTokenStore : IRefreshTokenStore
    {
        private readonly IDatabase _redis;
        public RedisRefreshTokenStore(IConnectionMultiplexer mux)
        {
            _redis = mux.GetDatabase();
        }
        public async Task<bool> ExistsAsync(Guid userId, string token)
        {
            return await _redis.KeyExistsAsync(
            $"refresh:{userId}:{token}");
        }

        public async Task RemoveAsync(Guid userId, string token)
        {
            await _redis.KeyDeleteAsync(
            $"refresh:{userId}:{token}");
        }

        public async Task SaveAsync(Guid userId, string token, TimeSpan ttl)
        {
            await _redis.StringSetAsync(
           $"refresh:{userId}:{token}",
           "1",
           ttl);
        }
    }
}

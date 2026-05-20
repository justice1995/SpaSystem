using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Interfaces
{
    public interface IRefreshTokenStore
    {
        Task SaveAsync(Guid userId, string token, TimeSpan ttl);
        Task<bool> ExistsAsync(Guid userId, string token);
        Task RemoveAsync(Guid userId, string token);
    }
}

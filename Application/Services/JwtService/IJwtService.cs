using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.JwtService
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string username, IEnumerable<string> roles);
    }
}

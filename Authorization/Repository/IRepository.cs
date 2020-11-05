using Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Repository
{
    public interface IRepository
    {
        string GenerateJSONWebToken(Member memberDetail);
    }
}

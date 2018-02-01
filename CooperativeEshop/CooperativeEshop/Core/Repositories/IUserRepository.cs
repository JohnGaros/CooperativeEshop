using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Core.Repositories
{
    public interface IUserRepository
    {
        IQueryable<AppUser> AppUsers { get; }
    }
}

using CooperativeEshop.Core.Repositories;
using CooperativeEshop.Core.Domain;
using System.Linq;
using System.Collections.Generic;

namespace CooperativeEshop.Persistence.Repositories
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(CoopEshopContext ctx) : base(ctx) {}

        public IQueryable<AppUser> AppUsers => Context.AppUsers;    
        
        
        
    }
}

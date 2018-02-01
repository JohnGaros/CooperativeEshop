using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Models.ViewModels
{
    public class AdminUsersViewModel
    {       
        //public IEnumerable<AppUser> Sellers { get; set; }
        //public IQueryable<AppUser> Customers { get; set; }
        public IQueryable<AppUser> AllUsers { get; set; }
    }
}

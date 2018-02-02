using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Models.ViewModels
{
    public class AdminUsersViewModel
    {       
        public IQueryable<AppUser> AllUsers { get; set; }       
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Models.ViewModels
{
    public class AdminSellersViewModel
    {
        public List<AppUser> AllSellers { get; set; }
    }
}

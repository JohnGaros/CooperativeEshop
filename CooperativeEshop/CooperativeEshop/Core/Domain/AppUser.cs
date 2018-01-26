using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CooperativeEshop.Core.Domain
{
    public class AppUser : IdentityUser
    {
        
        public Individual Individual { get; set; }
        public Organization Organization { get; set; }

        public ICollection<UserCommunicationChannel> UserCommunicationChannels { get; set; }
        
        public ICollection<PriceComponent> SellerPrices { get; set; }
    }
}

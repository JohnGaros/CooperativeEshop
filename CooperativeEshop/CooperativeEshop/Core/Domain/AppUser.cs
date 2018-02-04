
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CooperativeEshop.Core.Domain
{
    public class AppUser : IdentityUser
    {
        public decimal AccountBalance { get; set; }

        public Individual Individual { get; set; }
        public Organization Organization { get; set; }
        
        public Cart Cart { get; set; }
        
        public ICollection<UserCommunicationChannel> UserCommunicationChannels { get; set; }
        public ICollection<PriceComponent> SellerPrices { get; set; }
        public ICollection<InventoryItem> InventoryItems { get; set; }
        
    }
}

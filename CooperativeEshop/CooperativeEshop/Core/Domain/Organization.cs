using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class Organization 
    {
        public string OrganizationName { get; set; }
        public AppUser User { get; set; }
        public string UserID { get; set; }
    }
}

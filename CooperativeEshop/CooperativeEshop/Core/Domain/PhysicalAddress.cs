using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class PhysicalAddress
    {
        public CommunicationChannel CommChannel { get; set; }
        public int CommChannelID { get; set; }

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int Zip { get; set; }
    }
}

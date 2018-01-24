using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class Phone
    {
        public CommunicationChannel CommChannel { get; set; }
        public int CommChannelID { get; set; }

        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int PhoneNumber { get; set; }
    }
}

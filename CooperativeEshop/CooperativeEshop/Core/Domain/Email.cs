using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class Email
    {
        public CommunicationChannel CommChannel { get; set; }
        public int CommChannelID { get; set; }

        public string EmailAddress { get; set; }
    }
}

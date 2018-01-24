using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class CommunicationChannel
    {
        public int ID { get; set; }
        public ICollection<UserCommunicationChannel> UserCommunicationChannels { get; }

        public Phone Phone { get; set; }
        public Email Email { get; set; }
        public PhysicalAddress PhysicalAddress { get; set; }
    }
}

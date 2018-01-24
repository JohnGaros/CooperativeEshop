using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class CommunicationChannelType
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public ICollection<CommunicationChannel> CommChannels { get; set; }
    }
}

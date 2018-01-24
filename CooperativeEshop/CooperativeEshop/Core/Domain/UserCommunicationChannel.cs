﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Core.Domain
{
    public class UserCommunicationChannel
    {
        
        
        public AppUser User { get; set; }
      
        //[ForeignKey("User")]
        public string UserID { get; set; }
        
        public CommunicationChannel CommChannel { get; set; } 

        //[ForeignKey("CommChannel")]
        public int CommChannelID { get; set; }
    }
}

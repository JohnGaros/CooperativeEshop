using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativeEshop.Controllers
{
    public class Administration : Controller
    {
        public ViewResult Admin() => View();
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BCShop.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Policy = "AdminPolicy")]
	public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecureBadge.Entities;
using SecureBadge.Entities.Models;
using SecureBadge.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SecureBadge.API.Models;

namespace SecureBadge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Badges()
        {
            var service = new API.RestService();
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            
            var result = service.GetPinnedFileListAsync(user.FirstName+'_'+ user.LastName).Result;
            result.Add(new PinnedFileNameAndUrl()
            {
                Name = "Security Badge 7/24/2022 9:10 AM",
                Url = "https://securebadge.mypinata.cloud/ipfs/bafkreiaveconzuktyosgbjgvfe67jk3bfosticc4mpchs2eojwd4zza4x4?accessToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpbmRleGVzIjpbIjBhZjg0MjQwNzU0NTIyYTJiNWEzMjAzZTkwN2U3MzZlIl0sImFjY291bnRJZCI6IjM0OTliNTNjLThhOTEtNGYzNS04ZGY4LWM1ZjI2YjNiOTNlOCIsImlhdCI6MTY1ODY3MjU4MSwiZXhwIjoxNjU4Njc2MTgxfQ.5weK8av5ZsAr88YmDPkseJygFYALfXdT7x9E5MUslaA"

            });
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FacebookIntegration.Clients;

namespace FacebookIntegration.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly FacebookClient _fb = new FacebookClient();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var claimIdenties = HttpContext.User.Identity as ClaimsIdentity;
            var token = claimIdenties?.Claims.FirstOrDefault(_ => _.Type == "ExternalAccessToken");

            if (token != null)
            {
                ViewBag.Token = token;
                ViewBag.FriendsCount = await _fb.GetFriendsCount(token.Value);
            }
            return View();
        }
    }
}
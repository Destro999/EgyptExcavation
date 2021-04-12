using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [Authorize(Policy = "readpolicy")]
        public IActionResult Index()
        {
            ViewBag.NavBar = "Roles";
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        [Authorize(Policy = "writepolicy")]
        public IActionResult Create()
        {
            ViewBag.NavBar = "Roles";
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            ViewBag.NavBar = "Roles";
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
    }
}
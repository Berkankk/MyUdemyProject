using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var role = _roleManager.Roles.ToList();
            return View(role);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
        {
            AppRole appRole = new AppRole()
            {
                Name = addRoleViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole); //yeni bir rol oluşturmak için kullandık
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View("Hatalı giriş yaptınız lütfen kontol ediniz");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id) 
        {
            var value = _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleID = value.Id,
                RoleName = value.Name
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleView)
        {
            var value = _roleManager.Roles.FirstOrDefault(x=>x.Id == updateRoleView.RoleID);
            value.Name = updateRoleView.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");

        }
    }
}

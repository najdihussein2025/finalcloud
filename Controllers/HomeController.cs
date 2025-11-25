using System.Diagnostics;
using finalProject.Models;
using finalProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;

        public HomeController(ILogger<HomeController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAll();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.Add(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            await _userService.Update(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetById(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index");
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

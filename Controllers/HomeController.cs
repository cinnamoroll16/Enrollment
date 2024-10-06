using EnrollmentSystem.Models;
using EnrollmentSystem.Web.Models.Entities;
using EnrollmentSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using EnrollmentSystem.Web.Data;

namespace EnrollmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext; // Add the DbContext
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
        {
            this.dbContext = dbContext; // Initialize dbContext
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AddUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Return the same view with the current model to show validation errors
                return View(viewModel);
            }

            var user = new User
            {
                // Assuming UserID is provided by the user
                UserID = viewModel.UserID,
                UserName = viewModel.UserName,
                UserPassword = viewModel.UserPassword,
                Email = viewModel.Email
            };

            // Add the user to the correct DbSet
            await dbContext.Users.AddAsync(user); // Pass the user object here
            await dbContext.SaveChangesAsync();

            // Redirect to a different action after successful login
            return RedirectToAction("List", "Students"); // Ensure this action exists
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Home()
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

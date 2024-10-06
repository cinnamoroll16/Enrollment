using EnrollmentSystem.Models;
using EnrollmentSystem.Web.Data;
using EnrollmentSystem.Web.Models;
using EnrollmentSystem.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentSystem.Controllers
{
    public class SubjectSchedController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SubjectSchedController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

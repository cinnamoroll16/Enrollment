using EnrollmentSystem.Web.Data;
using EnrollmentSystem.Web.Models;
using EnrollmentSystem.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentSystem.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SubjectController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSubjectViewModel viewModel)
        {
            var subject = new Subject
            {
                SubjectCode = viewModel.SubjectCode,
                Description = viewModel.Description,
                Units = viewModel.Units,
                Offering = viewModel.Offering, // Ensure Offering exists in your ViewModel
                Category = viewModel.Category,
                Status = "Active", // You might want to change this based on your logic
                CourseCode = viewModel.CourseCode,
                Curriculum = viewModel.Curriculum
            };

            await dbContext.Subjects.AddAsync(subject);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Subjects"); // Use nameof for action name
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var subjects = await dbContext.Subjects.ToListAsync();
            return View(subjects);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var subject = await dbContext.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound(); // Return NotFound if the subject does not exist
            }
            return View(subject); // Return the subject for editing
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Subject viewModel) // Use a specific ViewModel if necessary
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel); // Return the view with validation errors
            }

            var subject = await dbContext.Subjects.FindAsync(viewModel.Id); // Ensure you're using the correct entity type

            if (subject != null)
            {
                subject.SubjectCode = viewModel.SubjectCode;
                subject.Description = viewModel.Description;
                subject.Units = viewModel.Units;
                subject.Offering = viewModel.Offering;
                subject.Category = viewModel.Category;
                subject.Status = viewModel.Status;
                subject.CourseCode = viewModel.CourseCode;
                subject.Curriculum = viewModel.Curriculum;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(List)); // Use nameof for action name consistency
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id) // Accept Guid instead of the full subject
        {
            var subject = await dbContext.Subjects
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (subject != null)
            {
                dbContext.Subjects.Remove(subject);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(List)); // Use nameof for action name
        }

    }
}

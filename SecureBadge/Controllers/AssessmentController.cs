using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureBadge.API;
using SecureBadge.Entities;
using SecureBadge.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureBadge.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public AssessmentController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var assessments = await _context.Assessments.ToListAsync();
            return View(assessments);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Assessment(int? id = 1)
        {
            var assessmentModel = new AssessmentModel();
            var assessment = await _context.Assessments.FirstOrDefaultAsync(x => x.AssessmentID == id);
            assessmentModel.AssessmentiD = (int)id;
            assessmentModel.Title = assessment.Title;
            var questions = await _context.Questions.Where(x => x.AssessmentID == id).ToListAsync();
            assessmentModel.Questions = new List<QuestionModel>();
            foreach(var question in questions)
            {
                var q = new QuestionModel();
                q.QuestionID = question.QuestionID;
                q.Text = question.Text;
                q.Choices = await _context.Choices.Where(x => x.QuestionID == question.QuestionID).ToListAsync();
                assessmentModel.Questions.Add(q);
            }
            return View(assessmentModel);
        }

        public IActionResult Badge()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Badge(AssessmentModel model)
        {
            var badge = new PdfBadgeGenerator();
            var badgeModel = new BadgeModel();
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            badgeModel.URL = badge.GeneratePdfBatch(user.FirstName, user.LastName);

            return View(badgeModel);
        }
    }
}

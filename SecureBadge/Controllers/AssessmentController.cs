﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public AssessmentController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id = 1)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitAssessment(AssessmentModel model)
        {
            var correctCount = 0;
            
            return View();
        }
    }
}

﻿using AutoMapper;
using CvMaker.Core.Models;
using CvMaker.Core.Services;
using CvMaker.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CvMaker.Web.Controllers
{
    public class CvController : Controller
    {
        // GET: CvController
        private readonly IMapper _mapper;
        private readonly ICurriculumVitaeService _cvService;
        public CvController(ICurriculumVitaeService curriculumVitae, IMapper mapper)
        {
            _cvService = curriculumVitae;
            _mapper = mapper;
        }

        public ActionResult List()
        {
            var cvs = _cvService.Query()
                .Include(cv => cv.Languages).ToList();
            var cvList = new CvListViewModel();
            cvList.CvItems = cvs.Select(cv => new CvItemModel
            {
                Email = cv.Email,
                Id = cv.Id,
                Name = cv.FirstName,
                LastName = cv.LastName,
                OtherName = cv.OtherName,
                PhoneNumber = cv.PhoneNumber
            }).ToList();
            return View(cvList);
        }

        // GET: CvController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {

            var cv = LoadCvWithRelatedEntities(id);

            var cvItemModel = _mapper.Map<CurriculumVitae, CvItemModel>(cv);

            bool ans = _cvService.CheckForInvalidPhoneNumber(cvItemModel.PhoneNumber);
            return View(cvItemModel);
        }

        // GET: CvController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CvController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CvItemModel cvItem)
        {
            if (ModelState.IsValid)
            {
                var cv = _mapper.Map<CvItemModel, CurriculumVitae>(cvItem);
                cv.Skills = new List<Skills> { new Skills() };
                cv.Languages = new List<LanguageKnowledge> { new LanguageKnowledge() };
                cv.Employments = new List<Employment> { new Employment() };
                cv.Educations = new List<Education> { new Education() };
                _cvService.Create(cv);
                var cvId = cv.Id;

                return RedirectToAction("CreateNextStep", new { id = cvId });
            }

            return View("Create", cvItem);
        }

        [HttpGet]
        public ActionResult CreateNextStep(int id)
        {
            var cv = LoadCvWithRelatedEntities(id);
            var cvItemModel = _mapper.Map<CurriculumVitae, CvItemModel>(cv);

            return View(cvItemModel);
        }

        [HttpPost]
        public IActionResult CreateNextStep(CvItemModel cvItemModel)
        {
            var existingCv = UpdateCvDetails(cvItemModel);
            
            _cvService.Update(existingCv);
            
            return RedirectToAction("List");
        }

        // GET: CvController/Edit/5
        public ActionResult Edit(int id)
        {
            var cv = LoadCvWithRelatedEntities(id);
            var cvItemModel = _mapper.Map<CurriculumVitae, CvItemModel>(cv);

            return View(cvItemModel);
        }

        // POST: CvController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CvItemModel cvItemModel)
        {
            var existingCv = UpdateCvDetails(cvItemModel);
            _cvService.Update(existingCv);
            return Redirect("List");
        }


        // POST: CvController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var cvToDelete = _cvService.GetById(id);
            if (cvToDelete != null)
            {
                _cvService.Delete(cvToDelete);
            }

            return RedirectToAction("List", "Cv");
        }

        private CurriculumVitae? LoadCvWithRelatedEntities(int cvId)
        {
            return _cvService.QueryById(cvId)
                .Include(l => l.Languages)
                .Include(s => s.Skills)
                .Include(a => a.Address)
                .Include(e => e.Educations)
                .Include(em => em.Employments)
                .SingleOrDefault();
        }

        private CurriculumVitae? UpdateCvDetails(CvItemModel cvItemModel)
        {
            var existingCv = LoadCvWithRelatedEntities(cvItemModel.Id);
            if (existingCv != null)
            {
                existingCv.Address = new Address
                {
                    City = cvItemModel.Address.City,
                    PostCode = cvItemModel.Address.PostCode,
                    StreetNumber = cvItemModel.Address.StreetNumber,
                    Street = cvItemModel.Address.Street,
                    Country = cvItemModel.Address.Country,
                    Id = cvItemModel.Address.Id,
                    CurriculumVitaeId = cvItemModel.Address.CurriculumVitaeId,
                };
                existingCv.Skills = cvItemModel.Skills.Select(s => new Skills
                {
                    CurriculumVitaeId = existingCv.Id,
                    Id = s.Id,
                    SkillDescription = s.SkillDescription,
                    SkillName = s.SkillName
                }).ToList();
                existingCv.Languages = cvItemModel.LanguageKnowledge.Select(lan => new LanguageKnowledge
                {
                    CurriculumVitaeId = existingCv.Id,
                    Id = lan.Id,
                    LanguageLevel = lan.LanguageLevel,
                    Language = lan.Language,
                }).ToList();
                existingCv.Employments = cvItemModel.Employments.Select(em => new Employment
                {
                    CurriculumVitaeId = existingCv.Id,
                    Id = em.Id,
                    EndDate = em.EndDate,
                    StartDate = em.StartDate,
                    JobPosition = em.JobPosition,
                    WorkLoad = em.WorkLoad,
                    NameOfCompany = em.NameOfCompany,
                }).ToList();
                existingCv.Educations = cvItemModel.Educations.Select(ed => new Education
                {
                    NameOfSchool = ed.NameOfSchool,
                    Faculty = ed.Faculty,
                    StudyProgram = ed.StudyProgram,
                    StudyEndDate = ed.StudyEndDate,
                    StudyStartDate = ed.StudyStartDate,
                    Status = ed.Status,
                    CurriculumVitaeId = existingCv.Id,
                    EducationalLevel = ed.EducationalLevel
                }).ToList();
            }

            return existingCv;
        }
    }
}
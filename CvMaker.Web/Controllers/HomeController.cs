using CvMaker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CvMaker.Core.Models;
using CvMaker.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CvMaker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<CurriculumVitae> _cvService;

        public HomeController(ILogger<HomeController> logger, IEntityService<CurriculumVitae> cvService)
        {
            _logger = logger;
            _cvService = cvService;
        }

        public IActionResult Index()
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
                PhoneNumber = cv.PhoneNumber,
                LanguageKnowledge = cv.Languages.Select(l => new LanguageKnowledgeViewModel
                {
                    CurriculumVitaeId = cv.Id,
                    Id = l.Id,
                    Language = l.Language,
                    LanguageLevel = l.LanguageLevel
                }).ToList()
            }).ToList();

            return View(cvList);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var cvToDelete = _cvService.GetById(id);
            if (cvToDelete != null)
            {
                _cvService.Delete(cvToDelete);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cvEdit = _cvService.QueryById(id)
                .Include(cv => cv.Languages)
                .SingleOrDefault();
            if (cvEdit != null)
            {
                var model = new CvItemModel
                {
                    Name = cvEdit.FirstName,
                    Email = cvEdit.Email,
                    Id = cvEdit.Id,
                    LanguageKnowledge = cvEdit.Languages.Select(l => new LanguageKnowledgeViewModel
                    {
                        CurriculumVitaeId = cvEdit.Id,
                        Id = l.Id,
                        Language = l.Language,
                        LanguageLevel = l.LanguageLevel
                    }).ToList()
                };
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CvItemModel cvItem)
        {
            var cv = _cvService.GetById(cvItem.Id);
            if (cv != null)
            {
                cv.Email = cvItem.Email;
                cv.FirstName = cvItem.Name;


                _cvService.Update(cv);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CvItemModel cvItem)
        {
            _cvService.Create(new CurriculumVitae
            {
                Email = cvItem.Email,
                FirstName = cvItem.Name,
                LastName = cvItem.LastName,
                OtherName = cvItem.OtherName,
                PhoneNumber = cvItem.PhoneNumber
            });
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
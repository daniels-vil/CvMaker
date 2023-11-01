using CvMaker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CvMaker.Core.Models;
using CvMaker.Core.Services;

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
            var cvs = _cvService.Get();
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
            var cvEdit = _cvService.GetById(id);
            if (cvEdit != null)
            {
                var model = new CvItemModel
                {
                    Name = cvEdit.FirstName,
                    Email = cvEdit.Email,
                    Id = cvEdit.Id
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
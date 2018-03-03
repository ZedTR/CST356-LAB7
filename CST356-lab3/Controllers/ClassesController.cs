
using System.Collections.Generic;
using CST356_lab3.ViewModel;
using System.Linq;
using CST356_lab3.Data.Entities;
using CST356_lab3.Data;
using System.Web.Mvc;

namespace CST356_lab3.Controllers
{
    public class ClassesController : Controller
    {
        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var Classes = GetClassForUser(userId);

            return View(Classes);
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewClassesModel  ClassViewModel)
        {
            if (ModelState.IsValid)
            {
                Save(ClassViewModel);
                return RedirectToAction("List", new { UserId = ClassViewModel.UserId });
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var Class = GetClass(id);

            DeleteClass(id);

            return RedirectToAction("List", new { UserId = Class.UserId });
        }

        private Classes GetClass(int cId)
        {
            var dbContext = new AppDb();

            return dbContext.Classes.Find(cId);
        }

        private ICollection<ViewClassesModel> GetClassForUser(int userId)
        {
            var ViewModels = new List<ViewClassesModel>();

            var dbContext = new AppDb();

            var classes = dbContext.Classes.Where(Class => Class.UserId == userId).ToList();

            foreach (var Class in classes)
            {
                var ClassViewModel = MapToClassViewModel(Class);
                ViewModels.Add(ClassViewModel);
            }

            return ViewModels;
        }

        private void Save(ViewClassesModel ClassViewModel)
        {
            var dbContext = new AppDb();

            var Class = MapToClass(ClassViewModel);

            dbContext.Classes.Add(Class);

            dbContext.SaveChanges();
        }

        private void DeleteClass(int id)
        {
            var dbContext = new AppDb();

            var Class = dbContext.Classes.Find(id);

            if (Class != null)
            {
                dbContext.Classes.Remove(Class);
                dbContext.SaveChanges();
            }
        }

        private Classes MapToClass(ViewClassesModel ViewModel)
        {
            return new Classes
            {
                Id = ViewModel.Id,
                ClassName = ViewModel.ClassName,
                StartDate = ViewModel.StartDate,
                EndDate = ViewModel.EndDate,
                UserId = ViewModel.UserId
            };
        }

        private ViewClassesModel MapToClassViewModel(Classes Class)
        {
            return new ViewClassesModel
            {
                Id = Class.Id,
                ClassName = Class.ClassName,
                StartDate = Class.StartDate,
                EndDate = Class.EndDate,
                UserId = Class.UserId
            };
        }
    }
}

/*
 Name: Zed Trzcinski
 Date: 2/9/2018
 Lab3
 
 */


using CST356_lab3.Data;
using CST356_lab3.Data.Entities;
using CST356_lab3.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;



namespace CST320_lab2.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewUserModel user)
        {
            var dbContext = new AppDb();
            if (ModelState.IsValid)
            {
                var _user = MapToUser(user);

                SaveUser(_user);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }
        private void SaveUser(User user)
        {
            var dbContext = new AppDb();

            dbContext.Users.Add(user);

            dbContext.SaveChanges();
        }

        // GET: User
        public ActionResult Index()
        {

            var users = GetAllUsers();

            return View(users);

        }

        public ActionResult List()
        {
            var users = GetAllUsers();

            return View(users);
        }

       
        public ActionResult Details(int id)
        {
            
            var user = GetUser(id);

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = GetUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(ViewUserModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateUser(userViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            DeleteUser(id);

            return RedirectToAction("List");
        }
        private void DeleteUser(int id)
        {
            var dbContext = new AppDb();

            var user = dbContext.Users.Find(id);

            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        private ViewUserModel GetUser(int id)
        {
            var dbContext = new AppDb();

            var user = dbContext.Users.Find(id);

            return MapToUserViewModel(user);
        }

        private IEnumerable<ViewUserModel> GetAllUsers()
        {
            var userViewModels = new List<ViewUserModel>();

            var dbContext = new AppDb();

            foreach (var user in dbContext.Users)
            {
                var userViewModel = MapToUserViewModel(user);
                userViewModels.Add(userViewModel);
            }

            return userViewModels;
        }
        private void UpdateUser(ViewUserModel userViewModel)
        {
            var dbContext = new AppDb();

            var user = dbContext.Users.Find(userViewModel.Id);

            CopyToUser(userViewModel, user);

            dbContext.SaveChanges();
        }
        private User MapToUser(ViewUserModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                GraduationDate = userViewModel.GraduationDate,
                YearsInSchool = userViewModel.YearsInSchool,
                Age = userViewModel.Age
            };
        }

        private ViewUserModel MapToUserViewModel(User user)
        {
            return new ViewUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                GraduationDate = user.GraduationDate,
                YearsInSchool = user.YearsInSchool,
                Age = user.Age
            };
        }

        private void CopyToUser(ViewUserModel userViewModel, User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.GraduationDate = userViewModel.GraduationDate;
            user.YearsInSchool = userViewModel.YearsInSchool;
            user.Age = userViewModel.Age;
        }
    }
}
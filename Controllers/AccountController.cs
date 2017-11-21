using ChildCare.Mapping;
using ChildCare.Models;
using ChildCareDAL;
using ParentDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildCare.Controllers
{
    public class AccountController : Controller
    {
        private UserDal UserDataAccess = new UserDal();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserPO form)
        {
            ActionResult result = null;
            if (ModelState.IsValid)
            {
                form.RoleID = 1;
                UserDO mappedUser = Mapper.MapUserPOToDO(form);
                bool success = UserDataAccess.RegisterUser(mappedUser);
                if (success)
                {
                    result = RedirectToAction("Index", "Home");
                }
                else
                {
                    result = View(form);
                }
            }
            else
            {
                result = View(form);
            }
            return result;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginPO form)
        {
            ActionResult result = null;
            if (ModelState.IsValid)
            {
                UserDO storedUserInfo = UserDataAccess.ViewUserByUsername(form.Username);
                if (storedUserInfo.Password == form.Password)
                {
                    //Login was a success
                    //Store information in session
                    Session["UserId"] = storedUserInfo.UserID;
                    Session["Username"] = storedUserInfo.UserName;
                    Session["FirstName"] = storedUserInfo.FirstName;
                    Session["LastName"] = storedUserInfo.LastName;
                    Session["RoleId"] = storedUserInfo.RoleID;

                    Session.Timeout = 6;//if 6 minutes elapses between no useage, 
                    //Redirect user to a working page.
                    result = RedirectToAction("Index", "Home");
                }
                else
                {
                    //Login failed due to password mismatch.
                    //Send user back to form.
                    result = View(form);
                }
            }
            else
            {
                //Form was not filled out appropriately.
                //Send user back to form.
                result = View(form);
            }
            return result;
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult ViewAllUsers()
        {
            List<UserPO> userList = new List<UserPO>();
            List<UserDO> dataObjects = UserDataAccess.ViewUsers();
            foreach (UserDO dataObject in dataObjects)
            {
                UserPO mappedUser = Mapper.MapUserDOToPO(dataObject);
                userList.Add(mappedUser);
            }
            return View(userList);
        }
        [HttpGet]
        public ActionResult UpdateAUser(Int64 userID)
        {
            UserDO userObject = UserDataAccess.ViewUserById(userID);
            UserPO mappedData = Mapper.MapUserDOToPO(userObject);
            return View(mappedData);
        }
        [HttpPost]
        public ActionResult UpdateAUser(UserPO form)
        {
            
                ActionResult result = null;
                if (ModelState.IsValid)
                {
                    UserDO mappedData = Mapper.MapUserPOToDO(form);
                    UserDataAccess.UpdateAUser(mappedData);
                    result = RedirectToAction("ViewAllUsers", "Account");
                }
                else
                {
                    result = View();
                }
                return result;
            
        }
        [HttpGet]
        public ActionResult DeleteAUser(Int64 userID)
        {
            UserDataAccess.DeleteAUser(userID);
            RedirectToAction("ViewAllUsers", "Account");
            return RedirectToAction("ViewAllUsers", "Account");
        }



    }
}


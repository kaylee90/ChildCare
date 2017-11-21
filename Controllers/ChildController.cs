using ChildCare.Mapping;
using ChildCare.Models;
using ChildCare.ViewModels;
using ChildCareDAL;
using ChildCareDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildCare.Controllers
{
    public class ChildController : Controller
    {
        private ParentDal parentDataAccess = new ParentDal();
        private ChildDal dataAccess = new ChildDal();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewAllChildren()
        {
            ActionResult result = null;

            if (Session["UserName"] != null)
            {
                List<ChildPO> childList = new List<ChildPO>();
                List<ChildDO> dataObjects = dataAccess.ViewChildren();
                foreach (ChildDO dataObject in dataObjects)
                {
                    ChildPO mappedChild = Mapper.MapChildDOToPO(dataObject);
                    childList.Add(mappedChild);
                }
                result = View(childList);
            }
            else
            {
                result = RedirectToAction("Login", "Account");
            }
            return result;
        }

        [HttpGet]
        public ActionResult CreateAChild()
        {
            ChildVM vm = new ChildVM();
            vm.ParentDropDown.Add(new SelectListItem() { Text = "Choose a parent", Value = "0" });
            foreach (ParentDO parent in parentDataAccess.ViewParents())
            {
                vm.ParentDropDown.Add(new SelectListItem { Text = parent.FirstName + " " + parent.LastName, Value = parent.ParentID.ToString() });
            }
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateAChild(ChildVM form)
        {
            ActionResult result = null;
            if (ModelState.IsValid)
            {
                ChildDO mappedData = Mapper.MapChildPOToDO(form.ChildForm);
                dataAccess.CreateAChild(mappedData);
                result = RedirectToAction("ViewAllChildren");
            }
            else
            {
                //Re-Populate your drop down list.
                result = View(form);
            }
            return result;
        }

        [HttpGet]
        public ActionResult UpdateAChild(Int64 childID)
        {
            ChildDO childObject = dataAccess.ViewChildById(childID);
            ChildPO mappedData = Mapper.MapChildDOToPO(childObject);
            return View(mappedData);
        }

        [HttpPost]
        public ActionResult UpdateAChild(ChildPO form)
        {
            ActionResult result = null;
            if (ModelState.IsValid)
            {
                ChildDO mappedData = Mapper.MapChildPOToDO(form);
                dataAccess.UpdateAChild(mappedData);
                result = RedirectToAction("ViewAllChildren", "Child");
            }
            else
            {
                result = View();
            }
            return result;
        }

        [HttpGet]
        public ActionResult DeleteAChild(Int64 childID)
        {
            dataAccess.DeleteAChild(childID);
            RedirectToAction("ViewAllChildren", "Child");
            return RedirectToAction("ViewAllChildren", "Child");
        }

        [HttpGet]
        public ActionResult ViewDetailsById(Int64 childID)
        {
            ChildDO childObject = dataAccess.ViewChildById(childID);
            ChildPO mappedData = Mapper.MapChildDOToPO(childObject);
            return View(mappedData);

        }
    }
}
using System;
using System.Collections.Generic;
using ChildCare.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChildCare.Mapping;
using ChildCareDAL;
using ChildCareDAL.Models;

namespace ChildCare.Controllers
{
    public class ParentController : Controller
    {
        private ParentDal DataAccess = new ParentDal();

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult ViewAllParents()
        {
            ParentDal dataAccess = new ParentDal();
            List<ParentPO> parentList = new List<ParentPO>();
            List<ParentDO> dataObjects = dataAccess.ViewParents();
            foreach (ParentDO dataObject in dataObjects)
            {
                ParentPO mappedParent = Mapper.MapParentDOToPO(dataObject);
                parentList.Add(mappedParent);
            }

            return View(parentList);
        }

        [HttpGet]
        public ActionResult CreateAParent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAParent(ParentPO form)
        {
            ActionResult result = null;
            if (Session["UserName"] != null)
            {
                if ((Int64)Session["RoleID"] == 1)
                {
                    if (ModelState.IsValid)
                    {
                        ParentDO mappedData = Mapper.MapParentPOToDO(form);
                        DataAccess.CreateAParent(mappedData);
                        result = RedirectToAction("ViewAllParents");
                    }
                    else
                    {
                        result = View(form);
                    }
                }
            }
            return result;

        }
        [HttpGet]
        public ActionResult UpdateAParent(Int64 parentID)
        {
            ParentDal dataAccess = new ParentDal();
            ParentDO parentObject = DataAccess.ViewParentById(parentID);
            ParentPO mappedData = Mapper.MapParentDOToPO(parentObject);
            return View(mappedData);
        }

        [HttpPost]
        public ActionResult UpdateAParent(ParentPO form)
        {
            ActionResult result = null;
            if (Session["UserName"] != null)
            {
                if ((Int64)Session["RoleID"] == 2)
                {


                    if (ModelState.IsValid)
                    {
                        ParentDO mappedData = Mapper.MapParentPOToDO(form);
                        DataAccess.UpdateAParent(mappedData);
                        result = RedirectToAction("ViewAllParents", "Parent");
                    }
                    else
                    {
                        result = View();
                    }
                }
                else
                {
                    result = RedirectToAction("Index", "Home");
                }
            }
            else
            {
            }
            return result;

        }
        [HttpGet]
        public ActionResult DeleteAParent(Int64 parentID)
        {
            if (Session["UserName"] != null)
            {
                if ((Int64)Session["RoleID"] == 3)
                {

                    DataAccess.DeleteAParent(parentID);
                    RedirectToAction("ViewAllParents", "Parent");
                }
                else
                {
                    
                }
            }
            else
            {
            }
            return RedirectToAction("ViewAllParents", "Parent");
        }
    }
}
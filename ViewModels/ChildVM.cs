namespace ChildCare.ViewModels
{
    using ChildCare.Models;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ChildVM
    {
        public ChildVM()
        {
            ParentDropDown = new List<SelectListItem>();
            AllChildren = new List<ChildPO>();
            ChildForm = new ChildPO();
        }

        public SelectList ParentSL { get; set; }

        public List<SelectListItem> ParentDropDown { get; set; }

        public ChildPO ChildForm { get; set; }

        public List<ChildPO> AllChildren { get; set; }

    }
}
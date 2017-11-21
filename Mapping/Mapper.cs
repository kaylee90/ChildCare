using ChildCare.Models;
using ChildCareDAL.Models;
using ParentDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChildCare.Mapping
{
    public class Mapper
    {
        public static ParentPO MapParentDOToPO(ParentDO parent)
        {
            ParentPO returnPO = new ParentPO();
            returnPO.ParentID = parent.ParentID;
            returnPO.FirstName = parent.FirstName;
            returnPO.LastName = parent.LastName;
            returnPO.Address = parent.Address;
            returnPO.Phone = parent.Phone;
            returnPO.PlaceOfWork = parent.PlaceOfWork;
            returnPO.WorkPhone = parent.WorkPhone;
            return returnPO;
        }

        public static ParentDO MapParentPOToDO(ParentPO parent)
        {
            ParentDO returnDO = new ParentDO();
            returnDO.ParentID = parent.ParentID;
            returnDO.FirstName = parent.FirstName;
            returnDO.LastName = parent.LastName;
            returnDO.Address = parent.Address;
            returnDO.Phone = parent.Phone;
            returnDO.PlaceOfWork = parent.PlaceOfWork;
            returnDO.WorkPhone = parent.WorkPhone;
            return returnDO;
        }
        public static ChildPO MapChildDOToPO(ChildDO child)
        {
            ChildPO returnPO = new ChildPO();
            returnPO.ChildID = child.ChildID;
            returnPO.FirstName = child.FirstName;
            returnPO.LastName = child.LastName;
            returnPO.Age = child.Age;
            returnPO.IsFemale = child.IsFemale;
            returnPO.IsPottyTrianed = child.IsPottyTrained;
            returnPO.Allergies = child.Allergies;
            returnPO.Medicine = child.Medicine;
            returnPO.VaccinationsUpToDate = child.VaccinationsUpToDate;
            returnPO.EmergencyContact = child.EmergencyContact;
            returnPO.EmergencyContactPhoneNumber = child.EmergencyContactPhoneNumber;
            returnPO.AuthorizedPeopleForPickUp = child.AuthorizedPeopleForPickUp;
            returnPO.ParentID = child.ParentID;
            return returnPO;
        }
        public static ChildDO MapChildPOToDO(ChildPO child)
        {
            ChildDO returnDO = new ChildDO();
            returnDO.ChildID = child.ChildID;
            returnDO.FirstName = child.FirstName;
            returnDO.LastName = child.LastName;
            returnDO.Age = child.Age;
            returnDO.IsFemale = child.IsFemale;
            returnDO.IsPottyTrained = child.IsPottyTrianed;
            returnDO.Allergies = child.Allergies;
            returnDO.Medicine = child.Medicine;
            returnDO.VaccinationsUpToDate = child.VaccinationsUpToDate;
            returnDO.EmergencyContact = child.EmergencyContact;
            returnDO.EmergencyContactPhoneNumber = child.EmergencyContactPhoneNumber;
            returnDO.AuthorizedPeopleForPickUp = child.AuthorizedPeopleForPickUp;
            returnDO.ParentID = child.ParentID;
            return returnDO;
        }
        public static UserPO MapUserDOToPO(UserDO user)
        {
            UserPO returnPO = new UserPO();
            returnPO.UserID = user.UserID;
            returnPO.FirstName = user.FirstName;
            returnPO.LastName = user.LastName;
            returnPO.UserName = user.UserName;
            returnPO.Password = user.Password;
            returnPO.RoleID = user.RoleID;
            return returnPO;
        }

        public static UserDO MapUserPOToDO(UserPO user)
        {
            UserDO returnDO = new UserDO();
            returnDO.UserID = user.UserID;
            returnDO.FirstName = user.FirstName;
            returnDO.LastName = user.LastName;
            returnDO.UserName = user.UserName;
            returnDO.Password = user.Password;
            returnDO.RoleID = user.RoleID;
            return returnDO;
        }
    }
}

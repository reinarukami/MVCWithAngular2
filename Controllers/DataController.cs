using MVCWithAngular2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithAngular2.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public JsonResult GetLastContact()
        {
            Contact c = null;

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                c = dc.Contacts.OrderByDescending(a => a.ContactID).Take(1).FirstOrDefault();
            }

            return new JsonResult { Data = c, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetGivenContact(GetContactModels Contact)
        {
            Contact c = null;

            using (MyDatabaseEntities data = new MyDatabaseEntities())
            {
                c = data.Contacts.Where(a => a.FirstName.Contains(Contact.Name) || a.LastName.Contains(Contact.Name)).Take(1).FirstOrDefault();
                //c = dc.Contacts.OrderByDescending(a => a.ContactID).Take(1).FirstOrDefault();
            }

            return new JsonResult { Data = c, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult UserLogin(LoginData login)
        {
            using (MyDatabaseEntities data = new MyDatabaseEntities())
            {
                var user = data.Logins.Where(a => a.Username.Equals(login.Username) && a.Password.Equals(login.Password)).FirstOrDefault();
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult GetEmployeeList()
        {

            List<Employee> employee = new List<Employee>();
            using (MyDatabaseEntities data = new MyDatabaseEntities())
            {
                employee = data.Employees.OrderBy(a => a.LastName).ToList();
            }

            return new JsonResult { Data = employee, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetCountries()
        {
            List<Country> country = new List<Country>();
            using (MyDatabaseEntities data = new MyDatabaseEntities())
            {
                country = data.Countries.OrderBy(a => a.CountryName).ToList();
            }

            return new JsonResult { Data = country, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetStates(int countryID)
        {
            List<State> state = new List<State>();
            using (MyDatabaseEntities data = new MyDatabaseEntities())
            {
                state = data.States.Where(a => a.CountryID == countryID).OrderBy(a => a.StateName).ToList();
            }

            return new JsonResult { Data = state, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult AddUser(Login Register)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                using(MyDatabaseEntities data = new MyDatabaseEntities())
                {
                    var existing = data.Logins.Where(a => a.Username.Equals(Register.Username)).FirstOrDefault();
                    if(existing == null)
                    {
                        data.Logins.Add(Register);
                        data.SaveChanges();
                        message = "success";
                    }
                    else
                    {
                        message = "user is already existing";
                    }
                }
            }
            else
            {
                message = "error";
            }

            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
           
        }


    }
}
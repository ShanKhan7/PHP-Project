using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication27
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        StudentDataContext db = new StudentDataContext();
        Student ob = new Student();
        [WebMethod]
        public int InsertData(string Name,int Age,string Email,string Gender,string City,string Subject)
        {
            var q = db.Students.Where(x => x.Name.Equals(Name) & x.Email.Equals(Email)).FirstOrDefault();
            if (q != null)
            {
                
                return 0;
            }
            else
            {
                ob.Name = Name;
                ob.Age = Age;
                ob.Email = Email;
                ob.Gender = Gender;
                ob.Subject = Subject;
                ob.City = City;
                db.Students.InsertOnSubmit(ob);
                db.SubmitChanges();
                return 1;   
            }
        }
        [WebMethod]
        public List<Student> Students()
        {
            var q = db.Students.ToList();
            return q;
        }
        [WebMethod]
        public int DeleteRecord(string Email)
    {
        var q = db.Students.Single(x => x.Email == Email);
        if (q != null)
        {
            db.Students.DeleteOnSubmit(q);
            db.SubmitChanges();
            return 1;
        }
        else
        {
            return 0;
        }
    }
        [WebMethod]
        public List<Student> SearchRecord(string Email)
        {
            var q = db.Students.Where(x => x.Email == Email).ToList();
            return q;
        }
    }
}

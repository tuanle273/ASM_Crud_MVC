using Role_Menu_MVC.Models;
using System.Linq;
using System.Web.Mvc;


namespace Role_Menu_MVC.Controllers
{
    public class StudentsController : Controller
    {
       StudentManagementEntities dbModels = new StudentManagementEntities();
        // GET: Students/Index
        public ActionResult Index(string searchString)
        {

            var lstStudent = dbModels.Students.ToList();
            var links = from student in lstStudent select student;
            if (!string.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.StudentID.Contains(searchString));
            }
            //return View(lstStudent);
            return View(links);
        }


        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            using (StudentManagementEntities dbModels = new StudentManagementEntities())
            {
                return View(dbModels.Students.Where(x => x.ID == id).FirstOrDefault());
            }

        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                using (StudentManagementEntities dbModels = new StudentManagementEntities())
                {
                    dbModels.Students.Add(student);
                    dbModels.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            using (StudentManagementEntities dbModels = new StudentManagementEntities())
            {
                return View(dbModels.Students.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                using (StudentManagementEntities dbModels = new StudentManagementEntities())
                {
                    dbModels.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    dbModels.SaveChanges();
                };
                // TODO: Add update logic here


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            using (StudentManagementEntities dbModels = new StudentManagementEntities())
            {
                return View(dbModels.Students.Where(x => x.ID == id).FirstOrDefault());

            }
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (StudentManagementEntities dbModels = new StudentManagementEntities())
                {
                    Student student = dbModels.Students.Where(x => x.ID == id).FirstOrDefault();
                    dbModels.Students.Remove(student);
                    dbModels.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

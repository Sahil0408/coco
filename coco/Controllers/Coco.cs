using coco.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
namespace coco.Controllers
{
 
    public class Coco : Controller
    {
        private readonly ApplicationDbContext _Context;
        public Coco(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public IActionResult Users()
        {
            List<Detailmodal>detaill=_Context.Details.ToList();
            Usersmodal obje =new Usersmodal();
            obje.details = detaill;
            return View(obje);
        }
        public IActionResult ForgotPassword()
        {
            return View(new Loginmodal());
        }

        [HttpPost]
        public IActionResult ForgotPassword(string Username)
        {

            Loginmodal fp = _Context.LoginTableModels.Where(s => s.Username == Username).SingleOrDefault();
            TempData["message"] = fp.Password;

            return View(fp);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About() 
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Login() 
        {
            Loginmodal log = new Loginmodal();
            return View(log);
        }
        [HttpPost]
        public IActionResult Login(Loginmodal log)
        {
           Loginmodal usr= _Context.LoginTableModels.Where(s => s.Username == log.Username && s.Password == log.Password).SingleOrDefault();
            if(usr!=null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Username or password is incorrect";
            }
            return View(new Loginmodal());
        }

        public IActionResult Registration() 
        {
            Registrationmodal obj = new Registrationmodal();
            return View(obj);
        }
        [HttpPost]
        public IActionResult Registration(Registrationmodal obj) 
        {
            Detailmodal Dm = new Detailmodal();
            Dm.Name = obj.Name;
            Dm.Age = obj.Age;
            Dm.Email = obj.Email;
            _Context.Details .Add(Dm);
            _Context.SaveChanges();

            Loginmodal Lm = new Loginmodal();
            Lm.Username = obj.Username;
            Lm.Password = obj.Password;
            Lm.Regid = Dm.Id;
            _Context.LoginTableModels.Add( Lm );
            _Context.SaveChanges();

            if (obj!=null)
            {
                TempData["Message"] = "Data Saved Successfully";
            }
            
            return View(new Registrationmodal());

        }
    }
    
}

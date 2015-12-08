using System.Web.Mvc;
using System.Web.Security;
using TourSite2.Models;

namespace TourSite2.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        //public AccountController(IAuthProvider auth)
        //{
        //    authProvider = auth;
        //}
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            FormsAuthProvider test = new FormsAuthProvider();

            if (ModelState.IsValid)
            {
                if (test.Authenticate(model.Username, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

    }
}
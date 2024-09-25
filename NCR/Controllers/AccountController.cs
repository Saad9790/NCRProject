using NCR;
using System.Linq;
using System.Web.Mvc;

public class AccountController : Controller
{
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        using (var context = new KamalESStagingDBAWSEntities())
        {
            // Find the user in the database
            var user = context.tbl_UsersAcount.FirstOrDefault(u => u.UserName == username);

            // Check if user exists and password matches
            if (user != null && user.NormalPassword == password) // Note: Compare hashed passwords in production
            {
                // Redirect to the dashboard on successful login
                return RedirectToAction("Assignedjob", "Home");
            }

            // If login fails, return to the login view with an error message
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }
    }

}

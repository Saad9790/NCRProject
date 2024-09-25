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
        // Implement your login logic here
        // For demonstration, just a simple check
        if (username == "admin" && password == "password")
        {
            // Redirect to the dashboard on successful login
            return RedirectToAction("Index", "Dashboard");
        }

        // If login fails, return to the login view with an error message
        ModelState.AddModelError("", "Invalid login attempt.");
        return View();
    }
}

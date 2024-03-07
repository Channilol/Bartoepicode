using Bartoepicode.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;

namespace Bartoepicode.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Utenti utente)
        {

            string connString = ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand login = new SqlCommand("SELECT * FROM Utenti WHERE Email = @Email and Password = @Password", conn);
                login.Parameters.AddWithValue("@Email", utente.Email);
                login.Parameters.AddWithValue("@Password", utente.Password);
                var reader = login.ExecuteReader();
                if(reader.HasRows)
                {
                    if(reader.Read())
                    {
                        bool admin = (bool)reader["Admin"];
                        int idUtente = (int)reader["IdUtente"];
                        if (admin)
                        {
                            FormsAuthentication.SetAuthCookie(idUtente.ToString(), true);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Le credenziali non sono valide");
                    return View(utente);
                }
                return View(utente);
            }
            catch (Exception ex) 
            {
                return View(utente);
            }
            finally 
            { 
                conn.Close();
            }
;
        }

        [Authorize, HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}
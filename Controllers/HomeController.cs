using Bartoepicode.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bartoepicode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var idUtente = HttpContext.User.Identity.Name;
                Utenti utente = new Utenti();
                string connString = ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    conn.Open();
                    SqlCommand userCheck = new SqlCommand("SELECT * FROM Utenti WHERE IdUtente = @IdUtente", conn);
                    userCheck.Parameters.AddWithValue("@IdUtente", idUtente);
                    var reader = userCheck.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if(reader.Read())
                        {
                            utente.Email = reader["Email"].ToString();
                            utente.Nome = reader["Nome"].ToString();
                            utente.Cognome = reader["Cognome"].ToString();
                        }
                    }
                    return View(utente);
                }
                catch (Exception ex)
                {
                    return Redirect("Error");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                return View();
            }
                
        }

        [Authorize]
        public ActionResult AdminPage()
        {
            return View();
        }
    }
}
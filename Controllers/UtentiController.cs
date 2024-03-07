using Bartoepicode.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Bartoepicode.Controllers
{
    public class UtentiController : Controller
    {
        private string connString = "Server=DESKTOP-E9R19JS\\SQLEXPRESS; Initial Catalog=Bartoepicode; Integrated Security=true; TrustServerCertificate=True";

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Utenti utente)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand register = new SqlCommand("INSERT INTO Utenti (Email, Password, Azienda, Nome, Cognome, CodiceFiscale, PartitaIVA, Admin) VALUES (@Email, @Password, @Azienda, @Nome, @Cognome, @CodiceFiscale, @PartitaIVA, @Admin)", conn);
                register.Parameters.AddWithValue("@Email", utente.Email);
                register.Parameters.AddWithValue("@Password", utente.Password);
                register.Parameters.AddWithValue("@Azienda", utente.Azienda);
                register.Parameters.AddWithValue("@Nome", utente.Nome);
                register.Parameters.AddWithValue("@Cognome", (object)utente.Cognome ?? DBNull.Value);
                register.Parameters.AddWithValue("@CodiceFiscale", (object)utente.CodiceFiscale ?? DBNull.Value);
                register.Parameters.AddWithValue("@PartitaIVA", (object)utente.PartitaIVA ?? DBNull.Value);
                register.Parameters.AddWithValue("@Admin", false);
                register.ExecuteNonQuery();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Add", "Utenti");
            }
            finally { conn.Close(); }

        }

    }
}
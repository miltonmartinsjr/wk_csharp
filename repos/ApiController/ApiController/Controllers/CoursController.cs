using ApiController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiController.Controllers
{
    public class CoursController : ApiController
    {
        Cours[] cours = new Cours[]
        {
            new Cours { Id_Cours = 1, Titre = "Tomato Soup", Situation = "Groceries"},
            new Cours { Id_Cours = 2, Titre = "Pates Soup", Situation = "Groceries"},
            new Cours { Id_Cours = 3, Titre = "Pommes de Terre Soup", Situation = "Groceries" }
        };

        public IEnumerable<Cours> GetAllCours()
        {
            return cours;
        }

        public IHttpActionResult GetCours(int id)
        {
            var product = cours.FirstOrDefault((p) => p.Id_Cours == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}

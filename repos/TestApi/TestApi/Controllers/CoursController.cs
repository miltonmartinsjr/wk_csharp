using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi.Models;

namespace TestApi.Controllers
{
    public class CoursController : ApiController
    {
        Cours[] courses = new Cours[]
        {
            new Cours { Id_Cours = 1, Titre = "Tomato Soup", Situation = "Groceries"},
            new Cours { Id_Cours = 2, Titre = "Yo-yo", Situation = "Toys" },
            new Cours { Id_Cours = 3, Titre = "Hammer", Situation = "Hardware" }
        };

        public IEnumerable<Cours> GetAllCours()
        {
            return courses;
        }

        public IHttpActionResult GetCours(int? id)
        {
            var cours = courses.FirstOrDefault((p) => p.Id_Cours == id);
            if (cours == null)
            {
                return NotFound();
            }
            return Ok(cours);
        }

    }
}

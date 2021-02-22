using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiController.Models
{
    public class Cours
    {
        public int Id_Cours { get; set; }
        public string Titre { get; set; }
        public string Situation { get; set; }
    }
}
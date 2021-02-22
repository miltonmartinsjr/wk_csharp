using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1
{
    public class HomeController : Controller
    {
        private readonly MvcTempContext _context;

        public HomeController (MvcTempContext context) {
                _context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Details(int? id)
        {

            var cours = await _context.Cours.FirstOrDefaultAsync(m => m.Id_Cours == id);
                
            if (cours == null)
                return NotFound();

            return View(cours);
        }

        public String Welcome()
        {
            return "Hello.";
        }
    }
}

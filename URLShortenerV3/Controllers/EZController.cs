using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using URLShortenerV3.Data;
using URLShortenerV3.Models;


// Controller that handles the views for the shortened URL and the ListAll pages

namespace URLShortenerV3.Controllers {

    public class EZController : Controller {

        private readonly LinkContext _context;

        public EZController(LinkContext context) {
            _context = context;
        }

        public IActionResult Index (int? id) {
            Console.WriteLine(id);
            return View();
        }

        public IActionResult ListAll(int? id) {
            Console.WriteLine(id);
            return View();
        }


    }

}
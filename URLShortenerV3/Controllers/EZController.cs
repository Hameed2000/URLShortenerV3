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
using URLShortenerV3.Repository;


// Controller that handles the views for the shortened URL and the ListAll pages

namespace URLShortenerV3.Controllers {

    public class EZController : Controller {

        private readonly LinkContext _context;
        private readonly ILinkRepository _linkRepository;

        public EZController(LinkContext context, ILinkRepository linkRepository) {
            _context = context;
            _linkRepository = linkRepository;
        }


        public IActionResult Index (int? id) {
            Console.WriteLine("GOT INDEX");
            Console.WriteLine(id);
            return View();
        }

        public IActionResult ListAll(int? id) {
            Console.WriteLine(id);
            return View();
        }



    }

}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortenerV3.Repository;
using URLShortenerV3.Models;

// Web API Controller
// Post request to add new entry
// Get request to get the long URL
// Get request to get thh

namespace URLShortenerV3.Controllers {
    [ApiController]
    public class LinksController : ControllerBase {

        private readonly ILinkRepository _linkRepository;
        
        public LinksController(ILinkRepository linkRepository) {
            _linkRepository = linkRepository;
        }

        [Route("api/[controller]")]
        [HttpPost]
        public async Task<ActionResult<Link>> CreateLink([FromBody] Link link) {
            var newLink = await _linkRepository.Create(link);
            Console.WriteLine("Create Link");
            if (newLink == null) {
                return UnprocessableEntity();
            }

            return newLink;
        }

        [Route("api/[controller]")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> GetLink(int id) {
            Console.WriteLine("Get link");
            
            var link = await _linkRepository.Get(id);

            if (link == null) {
                return NotFound();
            }

            return link;
        }

        [Route("api/[controller]/[action]/{ids}")]
        [HttpGet("{ids}")]
        public async Task<List<Link>> GetAllLinks(string ids) {
            Console.Write("Found");
            return await _linkRepository.GetAll(ids);
        }

    }

}
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortenerV3.Models;
using URLShortenerV3.Data;
using Microsoft.EntityFrameworkCore;

namespace URLShortenerV3.Repository {
    public class LinkRepository : ILinkRepository {

        private readonly LinkContext _context;

        public LinkRepository(LinkContext context) {
            _context = context;
        }

        public async Task<Link> Create(Link link) {

            if (!link.LongURL.StartsWith("http://") && !link.LongURL.StartsWith("https://")) {
                link.LongURL = "http://" + link.LongURL;
            }

            string longURL = link.LongURL;

            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex reg = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            bool good = reg.IsMatch(longURL);
            if (!good) {
                return null;
            }

            link.AmountUsed = 0;
            link.DateCreated = DateTime.Now;

            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return link;

        }

        public async Task<Link> Get(int id) {

            Link link = await _context.Links.FindAsync(id);

            link.AmountUsed++;
            await _context.SaveChangesAsync();

            return link;
            
        }

        public async Task<List<Link>> GetAll(string ids) {

            Console.WriteLine("THE LIST OF IDS IS BELOW THIS LINE");
            Console.WriteLine(ids);

            string[] idArr = ids.Split("_");
            int[] intArr = new int[idArr.Length];
            List<Link> entryList = new List<Link>(); 

            for (int i = 0; i < idArr.Length; i++) {
                int id = int.Parse(idArr[i]);
                var entry = await _context.Links.FindAsync(id);
                entryList.Add(entry);
            }

            return entryList;

        }

    }

}


/*string[] idArr = ids.Split("_");
Link[] entryArr = new Link[idArr.Length];

for (int i = 0; i < idArr.Length; i++) {
    int index;
    if (int.TryParse(idArr[i], out index)) {
        Console.WriteLine(index);
        var entry = _context.Links.Find(index);
        entryArr.Append(entry);
        Console.WriteLine(entry.LinkID);
    }
}
*/
using Microsoft.EntityFrameworkCore;
using URLShortenerV3.Models;

namespace URLShortenerV3.Data {
    public class LinkContext : DbContext {

        public LinkContext(DbContextOptions<LinkContext> options) : base(options) {

        }

        public DbSet<Link> Links { get; set; }

    }

}
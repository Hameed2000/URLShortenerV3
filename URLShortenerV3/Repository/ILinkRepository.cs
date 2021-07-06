using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortenerV3.Models;

namespace URLShortenerV3.Repository {
    public interface ILinkRepository {

        Task<Link> Create(Link link);

        Task<Link> Get(int id);

        Task<List<Link>> GetAll(string ids);

    }
}
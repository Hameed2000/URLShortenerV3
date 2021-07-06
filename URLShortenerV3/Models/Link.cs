using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// Link class, model for the data

namespace URLShortenerV3.Models {
    public class Link {

        public int LinkID { get; set; } //Goes to the end of the shortened URL
        public string LongURL { get; set; }
        public int AmountUsed { get; set; }
        public DateTime DateCreated { get; set; }

    }
}

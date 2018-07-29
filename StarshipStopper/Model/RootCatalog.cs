using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starshipStops.Model
{
    class RootCatalog
    {
        /// <summary>Total amount of starships in this page.</summary>
        public int Count { get; set; }

        /// <summary>URI to the next page of starships (if there is any).</summary>
        public string Next { get; set; }

        /// <summary>URI to the previous page of starships (if there is any).</summary>
        public string Previous { get; set; }

        /// <summary>List of starships at targeted page.</summary>
        public IEnumerable<Starship> Results { get; set; }
    }
}

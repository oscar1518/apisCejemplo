using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.DTO
{
    class SongDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int albumId { get; set; }
        public DateTime publishDate { get; set; }
    }
}

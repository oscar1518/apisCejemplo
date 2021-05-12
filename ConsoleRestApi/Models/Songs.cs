using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleRestApi.Models
{

    public class Song
    {
        public int id { get; set; }
        public string name { get; set; }
        public int albumId { get; set; }
        public DateTime publishDate { get; set; }
        public Album Album { get; set; }
    }
}

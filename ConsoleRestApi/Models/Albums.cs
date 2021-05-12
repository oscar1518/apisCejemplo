using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRestApi.Models
{

    public class Album
    {
        public int id { get; set; }
        public string name { get; set; }

        public int ArtistId { get; set; }
        public List<Song> songs { get; set; } = new List<Song>();
        public Artist artist { get; set; } = new Artist();

        //public override string ToString()
        //{
        //    string str = "";
        //    str += "Id: " + id + "\n";
        //    str += "Nombre: " + name + "\n";

        //    return str;
        //}
    }
    
}

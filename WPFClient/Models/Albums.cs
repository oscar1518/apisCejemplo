using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Models
{

    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
        public Artist Artist { get; set; } = new Artist();

        public string ArtistStr
        {
            get
            {
                return Artist.Name;
            }
        }
        public string SongsStr
        {
            get
            {
                string nombres = "";
                foreach (Song song in Songs)
                {
                    nombres = nombres + song.Name + ", ";
                }

                return nombres;
            }
        }

        //public override string ToString()
        //{
        //    string str = "";
        //    str += "Id: " + id + "\n";
        //    str += "Nombre: " + name + "\n";

        //    return str;
        //}
    }
    
}

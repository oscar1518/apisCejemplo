using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPFClient.Models
{

    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();
        public Album FirstAlbum
        {
            get
            {
                if (Albums.Any())
                {
                    return Albums.FirstOrDefault();
                }
                else
                {
                    return new Album();
                }
            }
        }
        public string AlbumsName {
            get {
                string nombres = "";
                foreach (Album album in Albums)
                {
                   nombres =  nombres + album.Name + ", ";
                }

                return nombres;
            }
        }

        public List<string> AlbumsNameList
        {
            get
            {
                List<string> nombres = new List<string>();
                foreach (Album album in Albums)
                {
                    nombres.Add(album.Name);
                }

                return nombres;
            }
        }

        //public override string ToString()
        //{
        //    string str = ""; 
        //    str += "****** Artista ******\n";
        //    str += "Id: " + Id + "\n";
        //    str += "Nombre: " + Name + "\n";
        //    str += "Edad: " + Age + "\n";
        //    str += "Género: " + Genre + "\n";
        //    str += "Albums: " + "\n";
        //    foreach (Album album in Albums)
        //    {
        //        str += "Álbum" + album.ToString() + "\n";
        //    }

        //    return str;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPFClient.Models
{

    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public DateTime PublishDate { get; set; }
        public Album Album { get; set; }

        public string NombreAlbum
        {
            get
            {
                return Album.Name;
            }
        }
    }
}

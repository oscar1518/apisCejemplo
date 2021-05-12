using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }

        //[ForeignKey("SongId")]
        public ICollection<Song> Songs { get; set; } = new List<Song>();

        public Artist Artist { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.Models
{
    [Table("albums")]
    public class Album
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("artist_id")]
        public int ArtistId { get; set; }

        //[ForeignKey("SongId")]
        public ICollection<Song> Songs { get; set; } = new List<Song>();

        public Artist Artist { get; set; }

    }
}

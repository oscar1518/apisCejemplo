using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.Models
{
    [Table("artists")]
    public class Artist
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("genre_molon")]
        public string Genre { get; set; }

        //[ForeignKey("AlbumId")]
        public ICollection<Album> Albums { get; set; } = new List<Album>();

    }

}

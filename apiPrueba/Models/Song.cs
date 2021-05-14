using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.Models
{
    [Table("songs")]
    public class Song
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("album_id")]
        public int AlbumId { get; set; }

        [Column("name")]
        [MaxLength(10)]
        public string Name { get; set; }

        [NotMapped]
        public string EstaPropiedadNoSirveParaNada { get; set; }

        [Column("publish_date")]
        public DateTime PublishDate { get; set; }

        [Column("EstaCancion_SeEscuchaMucho")]
        public int ReplaysNumber { get; set; }

        public virtual Album Album { get; set; }
    }
}

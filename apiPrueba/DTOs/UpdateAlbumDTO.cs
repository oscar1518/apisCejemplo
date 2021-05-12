using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.DTOs
{
    public class UpdateAlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }

        //[ForeignKey("SongId")]
    }
}

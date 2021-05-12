using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.DTOs
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SongDTO> Songs { get; set; } = new List<SongDTO>();
        public ArtistDTO Artist { get; set; }
    }
}

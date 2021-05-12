using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.DTOs
{
    public class CreateSongDTO
    {
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public DateTime PublishDate { get; set; }
    }

}

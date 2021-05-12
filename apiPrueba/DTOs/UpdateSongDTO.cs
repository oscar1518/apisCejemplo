using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.DTOs
{
    public class UpdateSongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

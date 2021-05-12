using apiPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public AlbumDTO Album { get; set; }

        //public string ArtistName { get; set; }
        //public int ArtistAge { get; set; }
    }
}
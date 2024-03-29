﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.Models
{
    [Table("Artists")]
    public class Artist
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }

        //[ForeignKey("AlbumId")]
        public ICollection<Album> Albums { get; set; } = new List<Album>();

    }

}
